﻿using Perpetuum.Players;
using Perpetuum.Services.EventServices;
using Perpetuum.Services.EventServices.EventMessages;
using Perpetuum.Services.RiftSystem;
using Perpetuum.Timers;
using Perpetuum.Units;
using Perpetuum.Zones.Intrusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perpetuum.Zones.NpcSystem
{
    /// <summary>
    /// Specifies the behavior of a Boss-type NPC with various settings
    /// </summary>
    public class NpcBossInfo
    {
        private readonly EventListenerService _eventChannel;
        private readonly int _id;
        private readonly double? _respawnNoiseFactor;
        private readonly long? _outpostEID;
        private readonly int? _stabilityPts;
        private readonly string _deathMsg;
        private readonly string _aggroMsg;
        private readonly CustomRiftConfig _riftConfig;
        private bool _speak;
        private bool overrideRelations;
        private readonly TimeKeeper _onDamageDebounce = new TimeKeeper(TimeSpan.FromSeconds(5));
        private readonly TimeKeeper _aggroDebounce = new TimeKeeper(TimeSpan.FromSeconds(5));

        private bool IsOutpostBoss { get { return _outpostEID != null; } }

        private int StabilityPoints { get { return _stabilityPts ?? 0; } }

        private bool HasRiftToSpawn { get { return _riftConfig != null; } }

        public int FlockId { get; }

        public TimeSpan RespawnTime { get; set; }

        public bool IsLootSplit { get; }

        public bool IsDead { get; private set; }

        public bool IsAnnounced { get; private set; }

        public NpcBossInfo(
            EventListenerService eventChannel,
            int id,
            int flockid,
            double? respawnNoiseFactor,
            bool lootSplit,
            long? outpostEID,
            int? stabilityPts,
            bool overrideRelations,
            string customDeathMsg,
            string customAggroMsg,
            CustomRiftConfig riftConfig,
            bool announce)
        {
            _eventChannel = eventChannel;
            _id = id;
            FlockId = flockid;
            _respawnNoiseFactor = respawnNoiseFactor;
            IsLootSplit = lootSplit;
            _outpostEID = outpostEID;
            _stabilityPts = stabilityPts;
            this.overrideRelations = overrideRelations;
            _deathMsg = customDeathMsg;
            _aggroMsg = customAggroMsg;
            _riftConfig = riftConfig;
            IsAnnounced = announce;
            _speak = true;
            IsDead = false;
        }

        /// <summary>
        /// Handle any actions when the boss loses aggro
        /// </summary>
        public void OnDeAggro()
        {
            _speak = true;
        }

        /// <summary>
        /// Handle any actions that this NPC Boss should do upon Aggression, including sending a message
        /// </summary>
        /// <param name="aggressor">Player aggressor</param>
        public void OnAggro(Player aggressor)
        {
            CommunicateAggression(aggressor);
            HandleBossOutpostAggro(aggressor);
        }



        /// <summary>
        /// Handle events to dispatch when the npc boss takes damage
        /// </summary>
        /// <param name="smartCreature">The npc Boss killed</param>
        /// <param name="aggressor">Player damager</param>
        public void OnDamageTaken(SmartCreature smartCreature, Player aggressor)
        {
            if (_onDamageDebounce.Expired)
            {
                PublishMessage(new NpcReinforcementsMessage(smartCreature, smartCreature.Zone.Id));
                _onDamageDebounce.Reset();
            }
        }

        /// <summary>
        /// Handle any death behavior for this Boss NPC
        /// Includes sending a message, and affecting outpost's stability if set
        /// </summary>
        /// <param name="npc">The npc Boss killed</param>
        /// <param name="killer">Player killer</param>
        public void OnDeath(Npc npc, Unit killer)
        {
            CommunicateDeath(killer);
            HandleBossOutpostDeath(npc, killer);
            SpawnPortal(npc, killer);
            IsDead = true;
            PublishMessage(new NpcReinforcementsMessage(npc, npc.Zone.Id));
            AnnounceDeath();
        }

        /// <summary>
        /// The boss lives again
        /// </summary>
        public void OnRespawn()
        {
            _speak = true;
            IsDead = false;
            AnnouceRespawn();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as NpcBossInfo);
        }

        public bool Equals(NpcBossInfo other)
        {
            return other != null && ReferenceEquals(this, other) || other._id == _id && other.FlockId == FlockId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;

                hash = hash * 31 + _id.GetHashCode();
                hash = hash * 31 + FlockId.GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// Apply any respawn timer modifiers
        /// </summary>
        /// <param name="respawnTime">normal respawn time of npc</param>
        /// <returns>modified respawn time of npc</returns>
        public TimeSpan GetNextSpawnTime(TimeSpan respawnTime)
        {
            var factor = _respawnNoiseFactor ?? 0.0;

            return respawnTime.Multiply(FastRandom.NextDouble(1.0 - factor, 1.0 + factor));
        }

        private void AnnouceRespawn()
        {
            if (!IsAnnounced)
            {
                return;
            }

            var randomDelay = FastRandom.NextTimeSpan(RespawnTime.Divide(5), RespawnTime.Divide(2));
            var timeStamp = DateTime.UtcNow;

            Task.Delay(randomDelay).ContinueWith((t) =>
            {
                PublishMessage(new NpcStateMessage(FlockId, NpcState.Alive, timeStamp));
            });
        }

        private void AnnounceDeath()
        {
            if (!IsAnnounced)
            {
                return;
            }

            PublishMessage(new NpcStateMessage(FlockId, NpcState.Dead, DateTime.UtcNow));
        }

        private void HandleBossOutpostAggro(Player aggressor)
        {
            if (IsOutpostBoss)
            {
                aggressor.ApplyPvPEffect();
            }
        }

        private void CommunicateAggression(Unit aggressor)
        {
            if (_aggroDebounce.Expired && _speak)
            {
                _speak = false;
                SendMessage(aggressor, _aggroMsg);
                _aggroDebounce.Reset();
            }
        }

        private void CommunicateDeath(Unit aggressor)
        {
            SendMessage(aggressor, _deathMsg);
        }

        private void HandleBossOutpostDeath(Npc npc, Unit killer)
        {
            if (!IsOutpostBoss)
            {
                return;
            }

            var zone = npc.Zone;

            IEnumerable<Unit> outposts = zone.Units.OfType<Outpost>();

            var outpost = outposts.First(o => o.Eid == _outpostEID);

            if (outpost is Outpost)
            {
                var participants = npc.ThreatManager.Hostiles
                    .Select(x => zone.ToPlayerOrGetOwnerPlayer(x.Unit))
                    .ToList();
                var builder = StabilityAffectingEvent.Builder()
                    .WithOutpost(outpost as Outpost)
                    .WithOverrideRelations(overrideRelations)
                    .WithSapDefinition(npc.Definition)
                    .WithSapEntityID(npc.Eid)
                    .WithPoints(StabilityPoints)
                    .AddParticipants(participants)
                    .WithWinnerCorp(zone.ToPlayerOrGetOwnerPlayer(killer).CorporationEid);

                PublishMessage(builder.Build());
            }
        }

        private void SpawnPortal(Npc npc, Unit killer)
        {
            if (!HasRiftToSpawn)
            {
                return;
            }

            PublishMessage(new SpawnPortalMessage(npc.Zone.Id, npc.CurrentPosition, _riftConfig));
        }

        private void SendMessage(Unit src, string msg)
        {
            if (!msg.IsNullOrEmpty())
            {
                PublishMessage(new NpcMessage(msg, src));
            }
        }

        private void PublishMessage(IEventMessage eventMessage)
        {
            _eventChannel.PublishMessage(eventMessage);
        }
    }
}
