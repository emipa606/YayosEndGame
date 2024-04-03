using HarmonyLib;
using RimWorld;
using Verse;

namespace yayoEnding;

[HarmonyPatch(typeof(ThingFilter), nameof(ThingFilter.SetFromPreset))]
internal class patch_ThingFilter_SetFromPreset
{
    [HarmonyPostfix]
    private static bool Prefix(ThingFilter __instance, StorageSettingsPreset preset)
    {
        if (preset == StorageSettingsPreset.DefaultStockpile)
        {
            __instance.SetAllow(ThingCategoryDef.Named("yy_gem_category"), true);
        }

        return true;
    }
}