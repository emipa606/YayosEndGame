using RimWorld;
using Verse;

namespace yayoEnding;

[DefOf]
public static class ThingDefOf
{
    public static ThingDef yy_biomeExtractor;

    static ThingDefOf()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
    }
}