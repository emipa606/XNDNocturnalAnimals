using Verse;

namespace NocturnalAnimals
{

    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        
        static HarmonyPatches()
        {
            //Harmony.DEBUG = true;
            NocturnalAnimals.HarmonyInstance.PatchAll();
        }

    }

}
