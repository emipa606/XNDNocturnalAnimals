using System.Collections.Generic;
using Verse;

namespace NocturnalAnimals;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class NocturnalAnimalsSettings : ModSettings
{
    public Dictionary<string, int> AnimalSleepType = new();
    private List<string> animalSleepTypeKeys;
    private List<int> animalSleepTypeValues;

    public bool VerboseLogging;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref VerboseLogging, "VerboseLogging");
        Scribe_Collections.Look(ref AnimalSleepType, "AnimalSleepType", LookMode.Value,
            LookMode.Value,
            ref animalSleepTypeKeys, ref animalSleepTypeValues);
    }

    public void ResetManualValues()
    {
        animalSleepTypeKeys = [];
        animalSleepTypeValues = [];
        AnimalSleepType = new Dictionary<string, int>();
        NocturnalAnimals.UpdateAnimalSleepTypes();
    }
}