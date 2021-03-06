﻿using System.Collections.Generic;
using System.Linq;

namespace IRTweaks
{

    public class AbilityOpts
    {
        public string FlexibleSensorLockId = "AbilityDefT8A";
        public string JuggernautId = "AbilityDefGu8";
        public string MultiTargetId = "AbilityDefG5";
    }

    public class StoreOpts
    {
        public int QuantityOnShift = 5;
        public int QuantityOnControl = 20;
    }

    public class CombatOpts
    {
        public int PilotAttributesMax = 13;

        public CalledShotOpts CalledShot = new CalledShotOpts();
        public class CalledShotOpts
        {

            public bool DisableAllLocations = true;
            public bool DisableHeadshots = true;

            public bool EnableTacticsModifier = true;

            public int BaseModifier = 6;
            public Dictionary<string, int> PilotTags = new Dictionary<string, int>();
        }

        public FlexibleSensorLockOptions FlexibleSensorLock = new FlexibleSensorLockOptions();
        public class FlexibleSensorLockOptions
        {
            public bool FreeActionWithAbility = false;
            public bool FreeActionWithStat = false;
            public string FreeActionStatName = "FreeSensorLock";
            public bool AlsoAppliesToActiveProbe = false;
        }

        public PainToleranceOpts PainTolerance = new PainToleranceOpts();
        public class PainToleranceOpts
        {
            public float ResistPerGuts = 10.0f;

            public float HeadDamageResistPenaltyPerArmorPoint = 5.0f;
            public float HeadHitArmorOnlyResistPenaltyMulti = 0.5f;

            // Reduces resist by this multiplied the capacity ratio of an ammo explosion
            public float AmmoExplosionResistPenaltyPerCapacityPercentile = 1.0f;
            // Reduces resist by this multiplied the capacity ratio of an head damage injury
            public float OverheatResistPenaltyPerHeatPercentile = 1.0f;

            public float KnockdownResistPenalty = 6f;
            public float SideLocationDestroyedResistPenalty = 10f;

        }

        public ScaledStructureOpts ScaledStructure = new ScaledStructureOpts();
        public class ScaledStructureOpts
        {
            public Dictionary<int, StructureScale> DifficultyScaling = new Dictionary<int, StructureScale>()
            {
                {  1, new StructureScale() { Mod = 0, Multi = 1f } },
                {  2, new StructureScale() { Mod = 0, Multi = 1.25f } },
                {  3, new StructureScale() { Mod = 0, Multi = 1.5f } },
                {  4, new StructureScale() { Mod = 0, Multi = 2f } },
                {  5, new StructureScale() { Mod = 0, Multi = 2.5f } },
                {  6, new StructureScale() { Mod = 0, Multi = 3f } },
                {  7, new StructureScale() { Mod = 0, Multi = 3.5f } },
                {  8, new StructureScale() { Mod = 0, Multi = 4f } },
                {  9, new StructureScale() { Mod = 0, Multi = 4.5f } },
                { 10, new StructureScale() { Mod = 0, Multi = 5f } }
            };

            public StructureScale DefaultScale = new StructureScale() { Mod = 0, Multi = 1f };

            public int MinDifficulty = 1;
            public int MaxDifficulty = 10;
        }

        public class StructureScale
        {
            public int Mod = 0;
            public float Multi = 1f;
        }

        public SpawnProtectionOpts SpawnProtection = new SpawnProtectionOpts();
        public class SpawnProtectionOpts
        {
            public bool ApplyGuard = true;

            public int EvasionPips = 6;

            public bool ApplyToEnemies = true;
            public bool ApplyToAllies = true;
            public bool ApplyToNeutrals = true;

            public bool ApplyToReinforcements = false;
        }

    }

    public class FixesFlags
    {

        // Combat
        public bool AlternateMechNamingStyle = true;
        public bool BuildingDamageColorChange = true;
        public bool BraceOnMeleeWithJuggernaut = true;
        public bool CalledShotTweaks = true;
        public bool ExtendedStats = true;
        public bool FlexibleSensorLock = true;
        public bool PainTolerance = true;
        public bool PathfinderTeamFix = true;
        public bool ScaleObjectiveBuildingStructure = true;
        public bool SpawnProtection = true;
        public bool UrbanExplosionsFix = true;

        // Misc
        public bool DisableCampaign = true;
        public bool DisableMPHashCalculation = true;
        public bool MultiTargetStat = true;
        public bool RandomStartByDifficulty = true;
        public bool ReduceSaveCompression = true;
        public bool ShowAllArgoUpgrades = true;
        public bool SkipDeleteSavePopup = true;
        public bool SkirmishReset = false;

        // UI
        public bool BulkPurchasing = true;
        public bool BulkScrapping = true;
        public bool CombatLog = true;
        public bool DisableCombatRestarts = true;
        public bool DisableCombatSaves = true;
        public bool MechbayLayout = true;
        public bool SkirmishAlwaysUnlimited = true;
        public bool SimGameDifficultyLabelsReplacer = true;
        public bool StreamlinedMainMenu = true;
        public bool WeaponTooltip = true;

    }

    public class ModConfig
    {

        // If true, many logs will be printed
        public bool Debug = false;
        // If true, all logs will be printed
        public bool Trace = false;

        public FixesFlags Fixes = new FixesFlags();

        public AbilityOpts Abilities = new AbilityOpts();
        public CombatOpts Combat = new CombatOpts();
        public StoreOpts Store = new StoreOpts();

        public void LogConfig()
        {
            Mod.Log.Info?.Write("=== MOD CONFIG BEGIN ===");
            Mod.Log.Info?.Write($"  DEBUG: {this.Debug} Trace: {this.Trace}");

            Mod.Log.Info?.Write("  -- Fixes --");
            Mod.Log.Info?.Write($"  AlternateMechNamingStyle:           {this.Fixes.AlternateMechNamingStyle}");
            Mod.Log.Info?.Write($"  BuildingDamageColorChange:          {this.Fixes.BuildingDamageColorChange}");
            Mod.Log.Info?.Write($"  BraceOnMeleeWithJuggernaut:         {this.Fixes.BraceOnMeleeWithJuggernaut}");
            Mod.Log.Info?.Write($"  BulkPurchasing:                     {this.Fixes.BulkPurchasing}");
            Mod.Log.Info?.Write($"  BulkScrapping:                      {this.Fixes.BulkScrapping}");
            Mod.Log.Info?.Write($"  CalledShotTweaks:                   {this.Fixes.CalledShotTweaks}");
            Mod.Log.Info?.Write($"  CombatLog:                          {this.Fixes.CombatLog}");
            Mod.Log.Info?.Write($"  DisableCampaign:                    {this.Fixes.DisableCampaign}");
            Mod.Log.Info?.Write($"  DisableCombatRestarts:              {this.Fixes.DisableCombatRestarts}");
            Mod.Log.Info?.Write($"  DisableCombatSaves:                 {this.Fixes.DisableCombatSaves}");
            Mod.Log.Info?.Write($"  DisableMPHashCalculation:           {this.Fixes.DisableMPHashCalculation}");
            Mod.Log.Info?.Write($"  ExtendedStats:                      {this.Fixes.ExtendedStats}");
            Mod.Log.Info?.Write($"  FlexibleSensorLock:                 {this.Fixes.FlexibleSensorLock}");
            Mod.Log.Info?.Write($"  MechbayLayoutFix:                   {this.Fixes.MechbayLayout}");
            Mod.Log.Info?.Write($"  PainTolerance:                      {this.Fixes.PainTolerance}");
            Mod.Log.Info?.Write($"  PathfinderTeamFix:                  {this.Fixes.PathfinderTeamFix}");
            Mod.Log.Info?.Write($"  RandomStartByDifficulty:            {this.Fixes.RandomStartByDifficulty}");
            Mod.Log.Info?.Write($"  ReduceSaveCompression:              {this.Fixes.ReduceSaveCompression}");
            Mod.Log.Info?.Write($"  ScaleObjectiveBuildingStructure:    {this.Fixes.ScaleObjectiveBuildingStructure}");
            Mod.Log.Info?.Write($"  ShowAllArgoUpgrades:                {this.Fixes.ShowAllArgoUpgrades}");
            Mod.Log.Info?.Write($"  SkipDeleteSavePopup:                {this.Fixes.SkipDeleteSavePopup}");
            Mod.Log.Info?.Write($"  SkirmishAlwaysUnlimited:            {this.Fixes.SkirmishAlwaysUnlimited}");
            Mod.Log.Info?.Write($"  SkirmishReset:                      {this.Fixes.SkirmishReset}");
            Mod.Log.Info?.Write($"  SimGameDifficultyLabelsReplacer:    {this.Fixes.SimGameDifficultyLabelsReplacer}");
            Mod.Log.Info?.Write($"  SpawnProtection:                    {this.Fixes.SpawnProtection}");
            Mod.Log.Info?.Write($"  StreamlinedMainMenu:                {this.Fixes.StreamlinedMainMenu}");
            Mod.Log.Info?.Write($"  UrbanExplosionsFix:                 {this.Fixes.UrbanExplosionsFix}");
            Mod.Log.Info?.Write($"  WeaponTooltips:                     {this.Fixes.WeaponTooltip}");

            Mod.Log.Info?.Write("  -- Called Shot --");
            Mod.Log.Info?.Write($"   Disable => AllLocations: {Combat.CalledShot.DisableAllLocations}  Headshots: {Combat.CalledShot.DisableHeadshots}");
            Mod.Log.Info?.Write($"   Enable => ComplexTacticsModifier: {Combat.CalledShot.EnableTacticsModifier}");
            Mod.Log.Info?.Write($"   BaseModifier:{Combat.CalledShot.BaseModifier}");
            foreach (KeyValuePair<string, int> kvp in Combat.CalledShot.PilotTags)
            {
                Mod.Log.Info?.Write($"   CalledShotPilotModifier - tag:{kvp.Key} modifier:{kvp.Value}");
            }
            Mod.Log.Info?.Write($"   CalledShotDefaultMod:{Combat.CalledShot.BaseModifier}");

            Mod.Log.Info?.Write("  -- Spawn Protection --");
            Mod.Log.Info?.Write($"   ApplyGuard:{Combat.SpawnProtection.ApplyGuard}  EvasionPips:{Combat.SpawnProtection.EvasionPips}");
            Mod.Log.Info?.Write($"   ApplyToEnemies:{Combat.SpawnProtection.ApplyToEnemies}  ApplyToAllies:{Combat.SpawnProtection.ApplyToAllies}  ApplyToNeutrals:{Combat.SpawnProtection.ApplyToNeutrals}  ");
            Mod.Log.Info?.Write($"   ApplyToReinforcements:{Combat.SpawnProtection.ApplyToReinforcements}");

            Mod.Log.Info?.Write("  -- Store --");
            Mod.Log.Info?.Write($"   QuantityOnShift:{Store.QuantityOnShift}  QuantityOnControl:{Store.QuantityOnControl}");

            Mod.Log.Info?.Write("  -- Flexible Sensor Lock Options --");
            Mod.Log.Info?.Write($"   FreeActionWithAbility:{this.Combat.FlexibleSensorLock.FreeActionWithAbility}  AbilityId:{this.Abilities.FlexibleSensorLockId}");

            Mod.Log.Info?.Write("=== MOD CONFIG END ===");
        }

        public void Init()
        {

            Mod.Log.Info?.Write("== Mod Config Initialization Started == ");

            // Iterate scaled structure, setting max and min
            if (Mod.Config.Fixes.ScaleObjectiveBuildingStructure)
            {
                if (Combat.ScaledStructure.DifficultyScaling.Keys.Count <= 0)
                    Mod.Log.Warn?.Write($"ScaleObjectiveBuildingStructure enabled but configuration is corrupt! This likely will cause errors!");

                if (Combat.ScaledStructure.DifficultyScaling.Keys.Count > 0)
                {
                    List<int> keys = Combat.ScaledStructure.DifficultyScaling.Keys.ToList<int>();
                    keys.Sort();
                    Combat.ScaledStructure.MinDifficulty = keys[0];
                    Combat.ScaledStructure.MaxDifficulty = keys[keys.Count - 1];
                    Mod.Log.Info?.Write($"ScaleObjectiveBuildingStructure has difficulties between {Combat.ScaledStructure.MinDifficulty} and {Combat.ScaledStructure.MaxDifficulty}");
                }

            }

            Mod.Log.Info?.Write("== Mod Config Initialization Complete == ");
        }
    }
}
