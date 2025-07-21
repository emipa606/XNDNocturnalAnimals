using Verse;

namespace NocturnalAnimals;

public class ExtendedRaceProperties : DefModExtension
{
    private static readonly ExtendedRaceProperties defaultValues = new();

    public BodyClock bodyClock;

    private static ExtendedRaceProperties get(Def def)
    {
        return def.GetModExtension<ExtendedRaceProperties>() ?? defaultValues;
    }


    public static void Update(ThingDef animal)
    {
        if (NocturnalAnimalsMod.Instance.Settings.AnimalSleepType.ContainsKey(animal.defName))
        {
            return;
        }

        var extendedRaceProps = get(animal);
        if (extendedRaceProps == null)
        {
            NocturnalAnimalsMod.Instance.Settings.AnimalSleepType[animal.defName] = 0;
            return;
        }


        NocturnalAnimalsMod.Instance.Settings.AnimalSleepType[animal.defName] =
            (int)extendedRaceProps.bodyClock;
    }
}