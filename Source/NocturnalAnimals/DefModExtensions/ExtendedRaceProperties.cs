using Verse;

namespace NocturnalAnimals
{

    public class ExtendedRaceProperties : DefModExtension
    {

        public BodyClock bodyClock;

        private static readonly ExtendedRaceProperties defaultValues = new ExtendedRaceProperties();

        public static ExtendedRaceProperties Get(Def def)
        {
            return def.GetModExtension<ExtendedRaceProperties>() ?? defaultValues;
        }

    }

}
