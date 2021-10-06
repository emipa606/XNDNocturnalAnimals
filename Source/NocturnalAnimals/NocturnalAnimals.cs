using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace NocturnalAnimals
{
    [StaticConstructorOnStartup]
    public class NocturnalAnimals
    {
        public static readonly List<ThingDef> AllAnimals;

        static NocturnalAnimals()
        {
#if DEBUG
                Log.Error("XeoNovaDan left debugging enabled in Nocturnal Animals - please let him know!");
#endif
            AllAnimals = DefDatabase<ThingDef>.AllDefsListForReading
                .Where(def => def.race is { Animal: true })
                .OrderBy(def => def.label).ToList();
            UpdateAnimalSleepTypesFromDefs();
            var HarmonyInstance = new Harmony("XeoNovaDan.NocturnalAnimals");
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static void UpdateAnimalSleepTypesFromDefs()
        {
            foreach (var animal in AllAnimals)
            {
                if (NocturnalAnimalsMod.instance.Settings.AnimalSleepType.ContainsKey(animal.defName))
                {
                    continue;
                }

                var extendedRaceProps = ExtendedRaceProperties.Get(animal);

                if (extendedRaceProps == null || extendedRaceProps.bodyClock == default)
                {
                    NocturnalAnimalsMod.instance.Settings.AnimalSleepType[animal.defName] = 0;
                    continue;
                }

                NocturnalAnimalsMod.instance.Settings.AnimalSleepType[animal.defName] =
                    (int)extendedRaceProps.bodyClock;
            }
        }
    }
}