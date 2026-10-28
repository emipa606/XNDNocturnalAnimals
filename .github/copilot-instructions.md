# GitHub Copilot Instructions for [XND] Nocturnal Animals (Continued)

Welcome to the [XND] Nocturnal Animals (Continued) mod for RimWorld. This mod adds different body clocks for animals, enhancing the immersion of the game world. Below are the detailed instructions to help you effectively use GitHub Copilot for developing this mod.

## Mod Overview and Purpose

The [XND] Nocturnal Animals (Continued) mod enhances the realism of animal behavior in RimWorld by implementing different types of circadian rhythms. These rhythms include:

- **Diurnal**: Animals are awake during the day and sleep through the night (default vanilla behavior).
- **Nocturnal**: Animals are awake during the night and sleep through the day.
- **Crepuscular**: Animals are awake during mornings and evenings, resting during the day and night.

The mod also includes in-game settings for all animals, allowing for customization and flexibility. Additionally, it adds a new "Cathemeral" type for animals that don't fit into the other categories.

## Key Features and Systems

### Body Clock Types
- **Diurnal**: Animals are awake during the day and sleep through the night.
- **Nocturnal**: Animals are awake during the night and sleep through the day.
- **Crepuscular**: Animals are awake during mornings and evenings, resting during the day and night.
- **Cathemeral**: Animals that have a mixed sleep pattern.

### In-Game Settings
- Customizable settings for each animal type.
- Support for legacy animals through patches.

### XML Integration
XML files are used to define and patch various animal types. Key XML files include:
- `LegacyArk.xml`
- `Races_Animal_BigCats.xml`
- `Races_Animal_Birds.xml`
- `Races_Animal_Giant.xml`
- `Races_Animal_Hares.xml`

### Harmony Patching
The mod uses the Harmony Patch Library to modify the behavior of vanilla and mod-added animals. This ensures compatibility with other mods.

## Coding Patterns and Conventions

### C# Coding Patterns
- **Mod Structure**: The mod is structured with a main class `NocturnalAnimals` that handles the core logic, a settings class `NocturnalAnimalsSettings`, and a mod class `NocturnalAnimalsMod`.
- **Method Naming**: Methods are named descriptively, such as `UpdateAnimalSleepTypes` and `ExposeData`.
- **Encapsulation**: Classes and methods are encapsulated to maintain clean and maintainable code.
- **Comments and Documentation**: Code is well-commented to explain complex logic and usage.

### XML Conventions
- **Def Files**: XML files are used to define and patch animal types.
- **Patch Structure**: Patches are structured to modify specific attributes or behaviors of animals.
- **Localization**: XML files include support for different languages, such as Russian and French.

## XML Integration

XML files are essential for defining and patching animal types. Here is an example of an XML patch file:

xml
<?xml version="1.0" encoding="utf-8"?>
<Defs>
  <PatchDef>
    <Operation Class="PatchOperationAdd">
      <xpath>/Defs/ThingDef[@defName="Animal_Fox"]</xpath>
      <value>
        <defName>Animal_Fox</defName>
        <bodyClockType>Nocturnal</bodyClockType>
      </value>
    </Operation>
  </PatchDef>
</Defs>


This patch file modifies the `Animal_Fox` def to set its body clock type to "Nocturnal".

## Harmony Patching

Harmony patching is used to modify the behavior of vanilla and mod-added animals. Here is an example of a Harmony patch in C#:

csharp
using HarmonyLib;
using RimWorld;
using Verse;

public static class NocturnalAnimals
{
    public static void UpdateAnimalSleepTypes()
    {
        foreach (var animal in Find.Map.mapPawns.AllPawns)
        {
            if (animal.RaceProps.bodyClockType == BodyClock.Nocturnal)
            {
                animal.mindState.duty = null;
                animal.jobs.EndCurrentJob(JobCondition.InterruptForced);
                animal.jobs.TryTakeOrderedJob(new Job(DefDatabase<JobDef>.GetNamed("NocturnalSleep")), JobCondition.InterruptForced);
            }
        }
    }
}


This code snippet uses Harmony to patch the `UpdateAnimalSleepTypes` method, modifying the behavior of nocturnal animals.

## Suggestions for Copilot

1. **Mod Structure**: Use Copilot to generate the basic structure of the mod, including the main class, settings class, and mod class.
2. **Method Implementations**: Use Copilot to generate method implementations, such as `UpdateAnimalSleepTypes` and `ExposeData`.
3. **XML Patches**: Use Copilot to generate XML patch files for defining and patching animal types.
4. **Harmony Patches**: Use Copilot to generate Harmony patches for modifying the behavior of vanilla and mod-added animals.
5. **Localization**: Use Copilot to generate XML files for different languages, such as Russian and French.

By following these instructions, you can effectively use GitHub Copilot to enhance and maintain the [XND] Nocturnal Animals (Continued) mod for RimWorld.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

