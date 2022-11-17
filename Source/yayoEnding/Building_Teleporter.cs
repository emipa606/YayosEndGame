using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace yayoEnding;

public class Building_Teleporter : Building
{
    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (var gizmo in base.GetGizmos())
        {
            yield return gizmo;
        }

        foreach (var gizmo2 in ShipUtility.ShipStartupGizmos(this))
        {
            yield return gizmo2;
        }

        var command_Action = new Command_Action
        {
            action = TryLaunch,
            defaultLabel = "yayoEnding_CommandTeleporterLaunch".Translate(),
            defaultDesc = "yayoEnding_CommandTeleporterLaunchDesc".Translate()
        };

        var comp = this.TryGetComp<CompHibernatable>();
        if (comp != null && comp.State == HibernatableStateDefOf.Hibernating)
        {
            command_Action.Disable("yayoEnding_energyChargeRequired".Translate());
        }
        else if (comp is { Running: false })
        {
            command_Action.Disable("yayoEnding_energyChargeRequired".Translate());
        }


        if (ShipCountdown.CountingDown)
        {
            command_Action.Disable();
        }

        command_Action.hotKey = KeyBindingDefOf.Misc1;
        command_Action.icon = ContentFinder<Texture2D>.Get("UI/Commands/LaunchShip");
        yield return command_Action;
    }

    public void ForceLaunch()
    {
        ShipCountdown.InitiateCountdown(this);
        if (Spawned)
        {
            QuestUtility.SendQuestTargetSignals(Map.Parent.questTags, "LaunchedShip");
        }
    }

    private void TryLaunch()
    {
        ForceLaunch();
    }
}