using HarmonyLib;
using RimWorld;
using Verse;

namespace yayoEnding;

[HarmonyPatch(typeof(ThingFilter), nameof(ThingFilter.SetFromPreset))]
internal static class ThingFilter_SetFromPreset
{
    public static void Postfix(ThingFilter __instance, StorageSettingsPreset preset)
    {
        if (preset == StorageSettingsPreset.DefaultStockpile)
        {
            __instance.SetAllow(ThingCategoryDef.Named("yy_gem_category"), true);
        }
    }
}