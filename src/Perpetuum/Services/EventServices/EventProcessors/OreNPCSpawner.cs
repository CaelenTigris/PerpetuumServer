﻿using Perpetuum.ExportedTypes;
using Perpetuum.Log;
using Perpetuum.Services.EventServices.EventMessages;
using Perpetuum.Zones;
using Perpetuum.Zones.Finders.PositionFinders;
using Perpetuum.Zones.NpcSystem.Reinforcements;
using Perpetuum.Zones.NpcSystem.Presences;
using Perpetuum.Zones.Terrains.Materials.Minerals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Perpetuum.Services.EventServices.EventProcessors
{
    /// <summary>
    /// EventListener for each zone, receives messages for mineralnode mined
    /// TODO need to track foreach node: is there a current npc, is there a new npc to be spawned
    /// </summary>
    public class OreNpcSpawner : EventProcessor<EventMessage>
    {
        private readonly int SPAWN_DIST_FROM_FIELD = 50;

        private readonly IZone _zone;
        private readonly IDictionary<MineralNode, DynamicPresence> spawnedPresences = new Dictionary<MineralNode, DynamicPresence>();
        private readonly IDictionary<MineralNode, INpcReinforcements> reinforcementsByMineralNode = new Dictionary<MineralNode, INpcReinforcements>();
        private readonly INpcReinforcementsRepository _npcReinforcementsRepo;
        private readonly IEnumerable<IMineralConfiguration> _mineralConfigs;

        public OreNpcSpawner(IZone zone, INpcReinforcementsRepository reinforcementsRepo, IMineralConfigurationReader mineralConfigurationReader)
        {
            _zone = zone;
            _npcReinforcementsRepo = reinforcementsRepo;
            _mineralConfigs = mineralConfigurationReader.ReadAll().Where(c => c.ZoneId == zone.Id);
        }

        private void OnPresenceExpired(Presence presence)
        {
            var matchedEntries = spawnedPresences.Where(p => p.Value.Equals(presence)).ToList();
            foreach (var pair in matchedEntries)
            {
                pair.Value.PresenceExpired -= OnPresenceExpired;
                spawnedPresences.Remove(pair.Key);
            }
        }

        private void RemoveEntry(MineralNode node)
        {
            if (spawnedPresences.ContainsKey(node))
            {
                if (spawnedPresences[node] != null)
                {
                    spawnedPresences[node].PresenceExpired -= OnPresenceExpired;
                }
                spawnedPresences.Remove(node);
            }
        }

        private Position FindSpawnLocation(Position start, double range)
        {
            var p = new Position();
            List<Point> result = null;
            for (int i = 0; i < 10; i++)
            {
                var random = FastRandom.NextDouble(0.0, 1.0);
                var pos = start.OffsetInDirection(random, range);
                var posFinder = new ClosestWalkablePositionFinder(_zone, pos);
                posFinder.Find(out p);
                result = _zone.FindWalkableArea(p, _zone.Size.ToArea(), 100);
                if (result != null)
                {
                    break;
                }
            }
            if (result == null)
            {
                return Position.Empty;
            }
            return p;
        }

        private double ComputeFieldPercentConsumed(MineralNode node)
        {
            var current = Convert.ToInt32(node.GetTotalAmount());
            var total = _mineralConfigs.Where(c => c.Type == node.Type).First().TotalAmountPerNode;
            var percent = 1.0 - (current / (double)total).Clamp();
            return percent;
        }

        private bool _spawning = false;

        public override void OnNext(EventMessage value)
        {
            if (value is OreNpcSpawnMessage msg && _zone.Id == msg.GetZoneID())
            {
                if (_spawning)
                {
                    return;
                }
                var node = msg.GetMineralNode();
                if (!reinforcementsByMineralNode.ContainsKey(node))
                {
                    var oreSpawn = _npcReinforcementsRepo.CreateOreNPCSpawn(node.Type);
                    reinforcementsByMineralNode.Add(node, oreSpawn);
                }
                Logger.Info(reinforcementsByMineralNode[node].ToString());
                if (spawnedPresences.ContainsKey(node))
                {
                    if (msg.GetOreNodeState() == OreNodeState.Removed)
                    {
                        //Node has been removed from zone - remove from our cache
                        RemoveEntry(node);
                    }
                    //There is an active presence
                    return;
                }
                var fieldCenter = node.Area.Center.ToPosition();
                var spawnPos = FindSpawnLocation(fieldCenter, SPAWN_DIST_FROM_FIELD);
                if (spawnPos == Position.Empty)
                {
                    return; // Failed to find valid spawn location, try again on next cycle
                }
                var percent = ComputeFieldPercentConsumed(node);
                var orePresence = reinforcementsByMineralNode[node].GetNextPresence(percent);
                if (orePresence == null)
                {
                    return; // Presence already spawned once, or not found
                }
                var delay = TimeSpan.FromSeconds(10);
                _zone.CreateBeam(BeamType.npc_egg_beam, b => b.WithPosition(fieldCenter).WithDuration(delay));
                _zone.CreateBeam(BeamType.teleport_storm, b => b.WithPosition(fieldCenter).WithDuration(delay));

                _spawning = true;
                Task.Delay(delay).ContinueWith(t =>
                {
                    try
                    {
                        var pres = _zone.AddDynamicPresenceToPosition(orePresence.Presence, fieldCenter, spawnPos, TimeSpan.FromSeconds(180)); // TODO timeout to 3 hr
                        orePresence.Spawned = true;
                        pres.PresenceExpired += OnPresenceExpired;
                        spawnedPresences.Add(node, pres);
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(ex);
                    }
                    finally
                    {
                        _spawning = false;
                    }
                });
            }
        }
    }
}
