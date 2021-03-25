
namespace Perpetuum
{
    public enum ErrorCodes
    {
        NoError = 0,
        SyntaxError,
        UnknownError,
        NoSuchCommand,
        RequiredArgumentIsNotSpecified,
        SyntaxErrorInDynpart,
        InsufficientPrivileges,
        DEPRECATED_CommandBlocked,
        TimeOut,
        RemoteExecutionError,
        ItemNotFound, //10
        CharacterNotFound,
        TooManyOrTooFewArguments,
        MaximumAmountOfRegisteredChannelsReached,
        NoSimultaneousLoginsAllowed,
        ChannelAlreadyRegistered,
        ChannelCantBeCreatedItsRegistered,
        SQLExecutionError,
        UserNotOnline,
        MaxSessionTimeReached,
        StringContainsNonWordCharacters,
        GotBanned,
        NoSuchUser,
        PasswordTooLong,
        NoSuchChannel,
        PasswordMismatch,
        NoSuchMember,
        NoSuchKey,
        TargetBlockedTheRequest,
        DEPRECATED_ParameterOutOfRange,
        DefinitionNotSupported, //30
        DEPRECATED_DefinitionNotSupportedAsHeadEntity,
        DEPRECATED_DefinitionNotSupportedAsParentEntity,
        DEPRECATED_TileMustBeNeighbouring,
        NotMemberOfCorporation,
        ItemAlreadyExists,
        MailFolderIndexIsOutOfRange,
        WTFErrorMedicalAttentionSuggested,
        MethodNotFound,
        UnknownPlugin,
        NameTaken,
        DEPRECATED_TimerCancelRequestError,

        // character

        CharacterAlreadySelected,
        CharacterNotEnoughMoney,


        // relay

        RelayListeningError,

        // user engine


        MailNotFound,

        // Extensions

        ExtensionNotFound,
        DEPRECATED_LearningInProgress,
        PrerequireExtensionError,

        // corporation

        NoSuchInvite,
        DEPRECATED_MemberNotFound,
        AccessDenied,
        MemberHasRolesError,

        NickTooShort,


        ServerError,

        NullExceptionError,
        DataConverterError,
        DEPRECATED_DataConverterUnknowDataType,

        AccountBanned,

        DEPRECATED_EntityDefaultNotFound,
        NotSignedIn,
        DEPRECATED_IllegalCategoryFlags,
        DEPRECATED_StorageFullError,
        EntityNotFound,
        InvalidMovement,
        DockingBaseNotFound,

        DEPRECATED_NameReserved,
        PluginMethodNotFound,
        SettingNotFound,
        DEPRECATED_NoActiveChassis,
        RobotNotFound,
        ParentError,

        CommandTimeBlocked,

        InvalidSlot,
        OwnerMismatch,
        ContainerIsFull,
        ContainerNotFound,
        SQLInsertError,
        SQLUpdateError,
        SQLDeleteError,
        DEPRECATED_EntityCreateError,
        UsedSlot,
        EmptySlot,

        LayerNotExists,
        NoMineralOnTile,
        MaximumAllowedAltitudeDifferenceExceeded,
        IllegalZone,
        DEPRECATED_AltitudeMinReached,
        DEPRECATED_AltitudeMaxReached,
        ModuleNotFound,
        DEPRECATED_KeyNotFound,
        LockTargetNotFound,

        ItemTypeMismatch,
        ItemNotStackable,
        ItemHasToBeRepackaged,
        StackFailed,
        ItemsAreNotInTheSameContainer,
        DEPRECATED_AlreadyPacked,
        DEPRECATED_ItemHasToBeRepaired,
        ItemNotPacked,
        DEPRECATED_NothingToRepair,
        FacilityTypeMismatch,
        RequiredComponentNotFound,
        CharacterHasToBeDocked,
        FacilityOutOfReach,
        DEPRECATED_NotDockedIn,

        MinimalQuantityNotReached,
        DEPRECATED_ChannelHasToBeEmpty,
        FacilityIsFull,
        MaximumAmountOfProducionsReached,
        ItemOutOfRange,
        FacilityLevelMismatch,
        NOT_USED,
        MarketItemsExceed,
        ExtensionLevelMismatch,
        EntityHasChildren,
        CategoryflagsMismatch,
        FacilityClosed,
        CharacterEIDNotFound,
        CyclicParenting,
        DEPRECATED_MaxNestingReached,
        InvalidAttribute,
        CharacterIsInInviteProgress,
        CorporationMaxMembersReached,
        CorporationNickTooLong,
        CorporationAlreadyMemberOfAnAlliance,
        CharacterNotOnline,
        DEPRECATED_CorporationHasMembers,
        PrivateCorporationAllowedOnly,
        CharacterMustBeABoardMember,
        AllianceMaxMembersReached,
        AllianceMaxDelegatesReached,
        CharacterNotInAlliance,
        AllianceNickTooLong,
        CorporationNotAMemberOfAnAlliance,
        CharacterMustBeInPrivateCorporation,
        CharacterMustBeInPrivateAlliance,
        DEPRECATED_EntityPositionNotFound,
        DEPRECATED_LockFailed,
        AccountExpired,
        CharacterInAllianceBoard,
        MaxLockedTargetExceed,
        CharacterMustNotABoardMember,
        CharacterIsCEOOperationFailed,
        AllianceRemoveCorporationRequired,
        PollClosed,
        CorporationMustBePrivate,
        CorporationHangarLeaseExpired,
        CorporationNotEnoughMoney,
        CharacterNotCorporationMember,
        corporationTransactionsFrozen,
        CorporationCharacterInJoinPeriod,
        OnlyAsciiAllowed,
        MaxNumberOfVotesReached,
        BasicCommoditiesAreNotReproccesable,
        CorporationMemberInLeavePeriod,
        NotMemberOfChannel,
        SearchStringTooShort,
        CharacterAlreadyOnChannel,
        PriceOutOfAverageRange,
        InvalidQuantity,
        ItemNotPurchasable,
        ItemQuantityHasToBeOne,
        ItemNotSellable,
        InvalidPosition,
        ItemNotUsable,
        OutOfPowergrid,
        OutOfCpu,
        DEPRECATED_ItemWithinMinimumDuration,
        MinimalDurationNotReached,
        MissionNotAvailable,
        MissionNoFreeSlot,
        DEPRECATED_MissionAgentIsNotATarget,
        CharacterAlreadyInGang,
        CharacterNotInGang,
        DEPRECATED_CharacterMustBeInGang,
        DEPRECATED_GangMaxMembersReached,
        MissionNothingToFetch,
        MissionFetchItemMissing,
        RobotMustbeSingleAndNonRepacked,
        CharacterNotInTheCurrentGang,
        OutOfCore,
        InvalidTarget,
        InvalidArea,
        AccountNotConfirmed,
        AmmoNotFound,
        OutOfAmmo,
        DEPRECATED_AmmoAlreadyLoaded,
        LOSFailed,
        FileReadError,
        FileWriteError,
        FileNotFoundError,
        FileInUseError,
        FileDeleteError,
        CreateDirError,
        IllegalPosition,
        InvalidTeleportChannel,
        CharacterHasToBeUnDocked,
        TeleportOutOfRange,
        DockingOutOfRange,
        ItemHealthMismatch,
        DEPRECATED_BeamNotFound,
        NotEnoughCore,
        RobotInCombat,
        StandingTooLow,
        DockingTimerStillRunning,
        TargetIsInvulnerable,
        AccuracyCheckFailed,
        MaximumAmountOfCharactersReached,
        DEPRECATED_AnotherCharacterIsLearning,
        ItemHasToBeUnpacked,
        DEPRECATED_SurfaceCovered,
        NoPlantOnTile,
        DEPRECATED_InvalidPlantIndex,
        DEPRECATED_PlantNotFruiting,
        DEPRECATED_PlantNotInFruitingState,
        TargetOutOfRange,
        TargetIsDead,
        TileNotSteppable,
        SearchFailed,
        DEPRECATED_InvalidZoneCommand,
        NickReservedForDevelopersAndGameMasters,
        MaxIterationsExceeded,
        YouAreHappyNow,
        NoSuchZone,
        NoSuchLayer,
        DEPRECATED_EffectNotFound,
        DEPRECATED_InvalidUnit,
        ShieldIsActive,
        ChassisBonusLevelMismatch,
        AmmoNotRequired,
        SpyAlert,
        HTTPPostError,
        HTTPGetError,
        ServerDisconnects,
        CategoryflagNotFound,
        InvalidCategoryFlag,
        InvitedMemberHasRoles,
        AmountTooHigh,
        RobotMustBeSelected,
        RelayIsClosedForPublic,
        ExtensionFullyLearnt,
        ItemQuantityMismatch,
        DEPRECATED_CharacterNotLearningAnyExtension,
        CharacterMustBeInDefaultCorporation,
        RobotMustBeDeselected,
        ARobotMustBeSelected,
        IllegalFileSize,
        DataNotLoaded,
        DEPRECATED_DataSizeMismatch,
        CorporationApplicationsNumberExceeded,
        CorporationNotExists,
        CorporationAppliacationNotFound,
        NotEnoughExtensionPoints,
        OnlyPrivateCorporationAcceptsApplication,
        TeleportSourceNotUsable,
        LootContainerNotFound,
        LootContainerOutOfRange,
        LootItemNotFound,
        LootItemIsBusy,
        InvalidLooter,
        InvalidLock,
        NoTeleportDestinations,
        AmountTooLow,
        ContainersAreNotSupported,
        ConsistencyError,
        DEPRECATED_NotEnoughCapacity,
        TemplateError,
        DEPRECATED_TargetSecurityStateTooHigh,
        TeleportDisabled,
        AccountHasBeenDisconnected,
        DEPRECATED_UnitInMovable,
        LockIsInProgress,
        InvalidEntityType,
        NickTaken,
        SOSStarted,
        CharacterIsInUse,
        InvalidAmmoDefinition,
        TrackingFailed,
        TargetIsNotLockable,
        InvalidLockType,
        TeleportTimerStillRunning,
        TargetIsNonAttackable,
        TargetNotFound,
        OnlyOnePerCategoryPerRobotAllowed,
        NickTooLong,
        InfiniteCapacityContainerNotSupported,
        ContainersAreNotSupportedTryCreatingACorporateFolder,
        MaxNumberOfHangarFoldersReached,
        CorporationMustBeActive,
        CorporationNameNotAllowedCharacters,
        CorporationNickNotAllowedCharacters,
        CorporationNameTooLong,
        PatentNotUsable,
        ModuleOutOfSpace,
        MaxNumberOfRunsReached,
        RobotHasItemsInContainer,
        RobotHasModulesEquipped,
        ContainerHasToBeInfinite,
        NothingToDo,
        ItemHasToBeRepaired,
        DEPRECATED_RobotMustBeEmpty,
        DEPRECATED_RobotContainerMustBeEmpty,
        ContainerHasToBeEmpty,
        ContainerHasToBeUnPacked,
        ItemNotPackable,
        CorporationDropCEOFirst,
        NoMaterialOnThePlant,
        CorporationMustBeDefault,
        AgentNotATarget,
        AgentOutOfReach,
        BasesOutOfRange,
        TextEmpty,
        NoAgentsOnBase,
        NickNotOffensive,
        StarterRobotRequestTimerIsStillRunning,
        GangNotFound,
        ServerOpenForAdminsOnly,
        StarterRobotFound,
        ItemNotRelocatable,
        PlantNotHarvestable,
        RobotIsInUse,
        PrimaryLockTargetNotFound,
        LockIsDisabled,
        RobotHasToBeRepaired,
        ChannelNotFound,
        ChannelNameTooLong,
        ChannelPasswordTooLong,
        OneApplicationAllowedPerCorporation,
        CorporationNameNotDefined,
        CorporationNickNotDefined,
        ItemHasToBeSingle,
        ZoneNotFound,
        AmmoLoadingInProgress,
        TeleportNotFound,
        TeleportDescriptionNotFound,
        PlayerNotFound,
        SessionNotFound,
        ItemIsNotPackaged,
        InvalidCharacterId,
        DefinitionCannotBeAddedToKnowledgeBase,
        ResearchLevelMismatch,
        ItemNotResearchable,
        PresenceNotFound,
        FlockNotFound,
        RobotComponentAlreadySupplied,
        RobotComponentNotSupplied,
        InvalidZoneId,
        DeliveryPointMismatch,
        RepairNotNeeded,
        InstanceNotFound,
        FieldContainerNotFound,
        NotAllowedForAggressors,
        CorporationChangeTooOften,
        CorporationNickTooShort,
        CorporationNameTooShort,
        CannotUnpackRobotInRobotInventory,

        ChannelAlreadyExists,
        NotMemberOfGang,
        ContainerTypeNotSupported,
        ProductionIsRunningOnThisLine,
        KnowledgeBaseMissingpoints,
        ProductionMaxCyclesExceeded,
        TooManyItemsToRelocate,
        PvpIsNotAllowed,
        CantDockThisState,
        AllTechlinesKnownForDefinition,
        UsePrototypeItemForResearch,
        MinimalQuantityNotReachedForMarket,
        CannotFittThisContainer,
        CorporationMaxMembersMismatch,
        TradeNotFound,
        TradeIsInProgress,
        TradeIsBlocked,
        TraderIsBusy,
        TraderIsOffline,
        DockingBaseMismatch,
        TraderHasToBeDocked,
        OnlyAlwaysStackableIsSupported,
        AdminIsNotBlockable,
        UnstackNotPossibleUseRelocate,
        ThisModuleIsNotSupportedOnNPCs,
        InsuranceAllowedForRobotsOnly,
        NotInsuredItem,
        MaximumInsurancesExceeded,
        CannotBuyFromYourself,
        NoAverageData,
        CharacterCreatedWithinADay,
        OperationNotAllowedOnInsuredItem,
        NoRobotFound,
        ServerFull,
        HackingDenied,
        AttackPointWasNotFound,
        AttackPointIsOutOfRange,
        SiegeDefinitionNotSupported,
        CharacterNotInSiege,
        CorporationAlreadySubscribedForSiege,
        SiegeAlreadyExpired,
        SiegeSubscriptionTimeIsOver,
        SiegeEventWasNotFound,
        NotEnoughSiegeTickets,
        SiegeEventAlreadyImmune,
        SiegeSiteAlreadyClaimed,
        SiegeSiteNotOwned,
        ItemIsInsuredOperationFails,
        CharacterIsBanned,
        GangNameTooShort,
        SiegeImmunityTimeIsOver,
        ResearchNotPossibleFromRobotCargo,
        CantBeUsedInPvp,
        MobileTeleportsAreNotDeployableNearBases,
        CharacterIsMuted,
        DecorIsRotated,
        DecorIsNot90DegreeRotated,
        DefinitionHasNoEnvironment,
        DecorScaled,
        RoleChangeOnLeavingMember,
        EmailNotConfirmed,
        OnlyEarlyAccessAllowed,
        CorporationNameReservedFromBeta,
        NotEnoughEPToDeleteCharacter,
        OffensiveNick,
        AccountTooOld,
        OnlyProtectedZonesAllowed,
        OnlyMainTerminalsAllowed,
        OperationNotAllowedInCombat,
        SiegeSubmitItemOverload,
        AllCharactersHasToBeDeleted,
        AccountResetNotPossible,
        MobileTeleportIsInRange,
        BlobEmitterInRange,
        CharacterDeleted,
        StarterRobotCantBeUsedYet,
        InvalidConditionsForPlanting,
        HarvestableVegetationAlreadyExistsOnTile,
        PlantingNotAllowedNearBases,
        TerrainTooSteep,
        CannotSubscribeToAnImmuneSiegeEvent,
        NotAvailableInTrial, //trial altal
        OperationNotPermittedOnTrialAccounts, //trial-ra -nak -tol
        IllegalMarketPrice,
        NoSuchAlliance,
        FacilityTypeAlreadyExistsOnBase,
        MissionAlarmAlreadyStarted,
        RobotUsedForProductionHasToBeRepackaged,
        NoPassableTileWasFound,
        ActiveCharactersOnAccount,
        CharacterIsBlocked,
        CharacterAlreadyFriend,
        NoSiegeFailsToNeutralize,
        NothingDefined,
        CorporationMustBeOlderToSiege,

        OnlyGangLeaderCanDoThis,
        NoSuchGangInvite,
        CharacterAlreadyHasPendingGangInvitation,

        ClientNotFound,
        ScanResultNotFound,
        GeoScannerModuleNotFound,
        TraceRouteTooEarly,
        MineralScanResultNotFound,
        MissionNoSwitchTargetActive,
        MissionNoItemSupplyActive,
        DecorLocked,
        UnitAlreadyScanned,
        MissionSwitchOutOfRange,
        CPRGNotProducible,
        ExtensionFrozen,
        ExtensionRemoveTimeOut,
        ExtensionLevelCantBeRemoved,
        ExtensionMaximumRemovedPerPeriod,
        ExtensionIsRequired,
        NotDeployableNearObject,
        MaximumAllowedRegistrationExceeded,
        SparkAlreadyActive,
        SparkAlreadyUnlocked,
        SparkCooldownNotOver,
        SparkNotEnoughItems,
        SparkLocked,
        StandingTooLowForDocking,
        OperationAllowedOnlyOnIntrusionSites,
        StabilityTooLow,
        DockingRightsChangeCooldownInProgress,
        NPCEggCanOnlyBeUsedOnMissionTargetSpot,
        IntrusionSiteNotFound,
        IntrusionSiteEffectBonusNotFound,
        NotEnoughIntrusionProductionPoints,
        IntrusionFacilityIsOnMaximumLevel,
        SetEffectChangeCooldownInProgress,
        DEPRECATED_AllowedOnUnprotectedZones,
        NotDeployableNearProbes,
        OnlyUnProtectedZonesAllowed,
        UnitsAround,
        TargetAltitudeDifferenceExceeded,
        ZoneNotTerraformable,
        TileTerraformProtected,
        TileBlocked,
        InvalidPlant,
        MaximumPlantStateReached,
        SAPIsInRange,
        MaximumAmountOfProbesReached,
        TooManyPlantsOfTypeInArea,
        TooCloseToOtherConstructibe,
        CEOWasActiveRecently,
        ProductionFacilityNotFound,
        PlantNotFertileOnThisZone,
        TooManyWallInArea,
        TooManyAdjacentWalls,
        BlockedTileWasFoundInConstructionRadius,
        NPCEggInRange,
        ConstructionLevelMaxReached,
        ConstructionLevelMinReached,
        ObjectNotFullyConstructed,
        NodeAlreadyConnected,
        CyclicConnection,
        TargetOutOfInConnections,
        SourceOutOfOutConnections,
        TargetOutOfTransmitRadius,
        BasesInBothNetworks,
        TargetIsIncompatible,
        ConnectionMustBeOutgoing,
        NotPossibleOnDamagedNode,
        NotPossibleOnOnlineNode,
        OnlyConsumersHaveWeight,
        NoBaseInNetwork,
        DockingBaseExistsInNetwork,
        MarketNotFound,
        NoDocumentReadAccess,
        NoDocumentWriteAccess,
        InvalidDocumentType,
        NotEnoughDocumentSlots,
        CharacterIsNotAFriend,
        DocumentVersionOld,
        NodeOffline,
        MaxDockingBasePerZoneReached,
        MaxDockingBasePerZonePerCorporationReached,
        OnlyControlTowerIsCompatible,
        FacilityTypeAlreadyConnected,
        OnlyPossibleAroundOwnedOutposts,
        DockingBaseNotSetToDeconstruct,
        DataAndSizeMismatch,
        MaximumStackSizeExceeded,
        OnlyConstructionPossible,
        OnlyDeconstructionPossible,
        OnlyEqualLevelsAllowed,
        MaximumResearchLevelReached,
        CharacterAlreadyHasLockedProject,
        ProjectAlreadyLocked,
        AreaTooLarge,
        BouyOutsideOfProject,
        ProjectAlreadySetInBuoy,
        NoProjectSetInBuoy,
        PlantingNotAllowedCloseToStructures,
        OnlyPossibleAroundOwnenStructures,
        ObjectAlreadyInFinishedState,
        PlayerInTerraformArea,
        TeleportIsTooClose,
        NotYourPBSObjectIsNear,
        ReactorIsFull,
        TerrainTooSteepAndBlockedTilesWasFound,
        ReinforceEndIsWithinOneDay,
        OnlyPBSDockingBaseAllowed,
        MiningEnablerEffectRequired,
        TeleportChannelInactive,
        MoreThanOneItemRequired,
        CPRGPointsToDifferentItems,
        ProjectNotLocked,
        NotPossibleDuringReinforce,
        BouyIsFinished,
        NoConcreteWasPlaced,
        NotEnoughCoins,
        OnlyGangLeaderOrAssistantCanDoThis,
        ItemNotRecyclable,
        ProductionLineIsAtZero,
        BaseAlreadySparkTeleportDestination,
        YouAreHereAlready,
        OnlyPrincipalAllowed,
        ItemRelocateFails,
        IllegalTransportAssignmentReward,
        IllegalTransportAssignmentCollateral,
        TransportAssignmentIsTaken,
        TransportAssignmentCancelTooEarly,
        NoItemsToTransport,
        ContainerInAssignment,
        NotEnoughSparkTeleportSlots,
        TransportAssignmentNotExpired,
        SourceDockingBaseNotFound,
        TargetDockingBaseWasNotFound,
        ContainerHasToBeOnADockingBase,
        TransportAssignmentIsNotTaken,
        TransportAssignmentExpired,

        ContainerHasNoName,
        TransportAssignmentAlreadyRetrieved,
        BuildingIsAtFullHealth,
        AccountNotFound,
        NotPossibleOnLifeTimeAccount,
        ExtensionLevelMismatchTerrain,
        OutOfItemGlobally,
        ThisAmountIsNotAvailable,
        SparkTeleportExtensionLevelTooLow,
        OutOfCargo,
        CharacterNotInTheOwnerGang,
        TeleportIsInRange,
        CantBeUsedInInvulnerable,
        TechTreeNodeNotFound,
        TechTreeAlreadyUnlocked,
        TechTreeUnlockParentMissing,
        TechTreeNotEnoughPoints,
        TechTreeAccessDenied,
        TechTreeEnablerExtensionMissing,
        NetworkHasReinforcedNode,
        NoMissionAvailableWithConditions,
        MissionCategoryNotDefined,
        MissionRunningWithCategoryAndLevel,
        NoSuchMineralOnZone,
        CantBeUsedInTeleportSickness,
        AccountNotEnoughMoney,
        TrainingCharacterInvolved,
        ExtensionMinimumReached,
        NoPvpInTraining,
        TooManyNodesOutOfCpu,
        SteamDecodingError,
        AccountNotPurchased,
        InputTooHigh,
        PlacedTooCloseToPBSDockingbase,
        NoOwnedBaseInRange,
        EnergyWellDepleted,
        BadTerraformLock,
        GatesAround,
        PlayerInGateArea,
        CannotUnpackRobotInVolumeWrapper,
        NameTooLong,
        ServerControlledPlanting,
        PlantingNotAllowedOnHighway,
        PlantingNotAllowedOnConcrete,
        SomeNodeAreOutsideOfNetworkRange,
        NoTeleportTargetsWereFound,
        InvalidMissionLocation,
        NoDeliveryAtLocation,
        DeliverTooEarly,
        OnlyMissionResearchKitAccepted,
        OnlyMissionItemAccepted,
        AllModulesHasToBeIdle,
        IntelAlreadyGathered,
        UnableToResolveMission,
        TooManyActiveCPRG,
        SelfTeleportEnablerMissing,
        NPCsGoneMissionAborted,
        MissionExpired,
        MissionAbortedByOwner,
        MissionItemCantBeProducedOnGamma,
        MissionItemCantBeForged,
        MissionItemCantBeResearchedOnGamma,
        RiftOutOfRange,
        RiftLevelMismatch,
        NoTransportAssignmentForContainer,
        TransportAssignmentCannotBeDeliveredHere,
        FittingOutOfPowergrid,
        FittingOutOfCpu,
        TargetIsNonAttackable_Reinforced,
        TargetIsNonAttackable_ControlTowerConnected,
        MissionNotFound,
        MissionAlreadyDone,
        MissionNoItemsFoundToDeliver,
        InviteOnlyServer,
        SteamLoginDisabled,
        AccountAlreadyExists,
        RobotWrongType
    }
}
