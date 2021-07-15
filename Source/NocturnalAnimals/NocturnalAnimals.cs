using HarmonyLib;
using Verse;

namespace NocturnalAnimals
{
    public class NocturnalAnimals : Mod
    {
        public static Harmony HarmonyInstance;

        public NocturnalAnimals(ModContentPack content) : base(content)
        {
#if DEBUG
                Log.Error("XeoNovaDan left debugging enabled in Nocturnal Animals - please let him know!");
#endif

            HarmonyInstance = new Harmony("XeoNovaDan.NocturnalAnimals");
        }
    }
}