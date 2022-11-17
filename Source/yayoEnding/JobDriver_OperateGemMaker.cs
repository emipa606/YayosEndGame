using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace yayoEnding;

public class JobDriver_OperateGemMaker : JobDriver
{
    public override bool TryMakePreToilReservations(bool errorOnFailed)
    {
        return pawn.Reserve(job.targetA, job, errorOnFailed: errorOnFailed);
    }

    protected override IEnumerable<Toil> MakeNewToils()
    {
        var f = this;
        f.FailOnDespawnedNullOrForbidden(TargetIndex.A);
        f.FailOnBurningImmobile(TargetIndex.A);
        f.FailOnThingHavingDesignation(TargetIndex.A, DesignationDefOf.Uninstall);
        f.FailOn(() => !job.targetA.Thing.TryGetComp<CompGemMaker>().CanDrillNow());
        yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.InteractionCell);
        var work = new Toil();
        work.tickAction = () =>
        {
            var actor = work.actor;
            ((ThingWithComps)actor.CurJob.targetA.Thing).GetComp<CompGemMaker>().DrillWorkDone(actor);
            actor.skills.Learn(SkillDefOf.Mining, 0.065f);
        };
        work.defaultCompleteMode = ToilCompleteMode.Never;
        work.WithEffect(EffecterDefOf.DisabledByEMP, TargetIndex.A);
        work.FailOnCannotTouch(TargetIndex.A, PathEndMode.InteractionCell);
        work.activeSkill = () => SkillDefOf.Mining;
        yield return work;
    }
}