using HarmonyLib;
using Verse;

namespace yayoEnding;

public class harmonyPatch : Mod
{
    public harmonyPatch(ModContentPack content) : base(content)
    {
        new Harmony("yayoEnding").PatchAll();
    }
}

// 탄약 카테고리 보이기