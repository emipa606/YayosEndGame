using System;
using RimWorld;
using Verse;

namespace yayoEnding;

public class CompGemMaker : ThingComp
{
    private const float WorkPerPortionBase = 2000f * 60f;
    private int lastUsedTick = -99999;
    private float portionProgress;
    private float portionYieldPct;
    private CompPowerTrader powerComp;

    private ThingDef gemDef
    {
        get
        {
            var t = ThingDef.Named($"yy_gem_{parent.Map.Biome.defName}");

            return t;
        }
    }

    [Obsolete("Use WorkPerPortionBase constant directly.")]
    public static float WorkPerPortionCurrentDifficulty => WorkPerPortionBase;

    public float ProgressToNextPortionPercent => portionProgress / WorkPerPortionBase;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        powerComp = parent.TryGetComp<CompPowerTrader>();
    }

    public override void PostExposeData()
    {
        Scribe_Values.Look(ref portionProgress, "portionProgress");
        Scribe_Values.Look(ref portionYieldPct, "portionYieldPct");
        Scribe_Values.Look(ref lastUsedTick, "lastUsedTick");
    }

    public void DrillWorkDone(Pawn driller)
    {
        var statValue = driller.GetStatValue(StatDefOf.DeepDrillingSpeed) * core.extractSpeed;
        portionProgress += statValue;
        portionYieldPct +=
            (float)(statValue * (double)driller.GetStatValue(StatDefOf.MiningYield) / WorkPerPortionBase);
        lastUsedTick = Find.TickManager.TicksGame;
        if ((double)portionProgress <= WorkPerPortionBase)
        {
            return;
        }

        TryProducePortion();
        portionProgress = 0.0f;
        portionYieldPct = 0.0f;
    }

    public override void PostDeSpawn(Map map)
    {
        portionProgress = 0.0f;
        portionYieldPct = 0.0f;
        lastUsedTick = -99999;
    }

    private void TryProducePortion()
    {
        var m = parent.Map;
        var thing = ThingMaker.MakeThing(gemDef);
        thing.stackCount = Rand.Range(3, 9);
        GenPlace.TryPlaceThing(thing, parent.InteractionCell, m, ThingPlaceMode.Near);
    }

    public bool CanDrillNow()
    {
        return powerComp is not { PowerOn: false };
    }

    public bool UsedLastTick()
    {
        return lastUsedTick >= Find.TickManager.TicksGame - 1;
    }

    public override string CompInspectStringExtra()
    {
        if (!parent.Spawned)
        {
            return null;
        }

        return "yayoEnding_resource".Translate() + ": " + gemDef.label + "\n" + "ProgressToNextPortion".Translate() +
               ": " + ProgressToNextPortionPercent.ToStringPercent("F0");
    }
}