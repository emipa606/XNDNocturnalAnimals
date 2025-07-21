using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace NocturnalAnimals;

[HarmonyPatch(typeof(RaceProperties), nameof(RaceProperties.SpecialDisplayStats))]
public static class RaceProperties_SpecialDisplayStats
{
    public static void Postfix(ThingDef parentDef, ref IEnumerable<StatDrawEntry> __result)
    {
        var bodyClock = BodyClock.Diurnal;
        if (NocturnalAnimalsMod.Instance.Settings.AnimalSleepType.TryGetValue(parentDef.defName, out var value))
        {
            bodyClock = (BodyClock)value;
        }

        // Body clock
        __result = __result.AddItem(new StatDrawEntry(StatCategoryDefOf.BasicsPawn,
            "NocturnalAnimals.BodyClock".Translate(),
            $"NocturnalAnimals.BodyClock_{bodyClock}".Translate(),
            "NocturnalAnimals.BodyClock_Description".Translate(), 2090));
    }
}