# GitHub Copilot Instructions for RimWorld Modding Project

Thank you for contributing to this RimWorld modding project. This file provides an overview of the mod, its key features, and systems, as well as coding patterns, XML integration methods, Harmony patching, and how to work effectively with GitHub Copilot.

## Mod Overview and Purpose
This mod is designed to enhance the gameplay experience in RimWorld by introducing new race properties and behavioral mechanics for animals, focusing on nocturnal and diurnal activities. The primary goal is to add depth and realism to animal behaviors based on the time of day, affecting their activity patterns across different races.

## Key Features and Systems
- **Extended Race Properties**: Enhancements allow modders to define specific behaviors for different animal races, particularly focusing on nocturnal and diurnal activity cycles.
- **Dynamic Body Clock**: Implements biological clock behaviors for animals to simulate realistic rest and activity cycles.
- **Customized Job Prioritization**: Modifies task assignment through job priorities based on an animal's active hours.
- **Special Display Information**: Provides additional insights about animals via extended race properties, accessible in the game's information panels.

## Coding Patterns and Conventions
- **DefModExtensions**: This pattern is used in the `ExtendedRaceProperties.cs` file for extending the `Def` definitions with additional data fields.
- **Static Classes for Patching**: Harmony patches are managed in static classes, such as `Patch_JobGiver_GetRest` and `Patch_RaceProperties`, organized by the functionality they modify.
- **Private Method Conventions**: Helper methods, such as `DrawIcon` in `NocturnalAnimalsMod.cs`, are kept private and are called internally to maintain encapsulation.

## XML Integration
- XML is used to define properties and attributes for animals that are parsed and interpreted by `ExtendedRaceProperties`. Mod developers should adhere to XML conventions for compatibility and maintain proper file structures for RimWorld modding.

## Harmony Patching
- Harmony is used for altering base game functionality. Static classes such as `Patch_JobGiver_GetRest` and `Patch_RaceProperties` contain patches that modify game methods to implement custom behavior like rest priority for nocturnal animals.
- Follow best practices for Harmony patching to avoid conflicts, and ensure compatibility with other mods by checking for existing patches on targeted methods.

## Suggestions for Copilot
- When generating methods for handling XML data, consider inputs for different animal race properties and ensure they are compatible with existing Def structures.
- While designing Harmony patches, instruct Copilot to create safety checks for existing prefixes, postfixes, or transpilers to prevent overriding existing mod patches.
- Utilize Copilot to automate the generation of boilerplate C# code for new ModSettings features, focusing on user interface settings customization.
- For debugging purposes, suggest meaningful log messages in each method, especially when modifying crucial game mechanics like animal job prioritization or race property extensions.

## Conclusion
This mod project provides a versatile framework for expanding RimWorld's animal behavior dynamics. Contributors should follow established coding patterns, utilize XML for flexible data editing, and perform careful Harmony patching to maintain compatibility across different mods. Utilize Copilot as an efficient tool to streamline development tasks and ensure adherence to project standards. Happy modding!
