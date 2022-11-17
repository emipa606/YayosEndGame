using HarmonyLib;
using RimWorld;

namespace yayoEnding;

[HarmonyPatch(typeof(DefGenerator), "GenerateImpliedDefs_PreResolve")]
public class Patch_DefGenerator_GenerateImpliedDefs_PreResolve
{
    public static void Prefix()
    {
        core.patchDef();
    }
}