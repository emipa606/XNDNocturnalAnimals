using Verse;

namespace NocturnalAnimals;

public class ExtendedRaceProperties : DefModExtension
{
    private static readonly ExtendedRaceProperties defaultValues = new ExtendedRaceProperties();

    public BodyClock bodyClock;

    public static ExtendedRaceProperties Get(Def def)
    {
        return def.GetModExtension<ExtendedRaceProperties>() ?? defaultValues;
    }
}