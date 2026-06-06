# GitHub Copilot Instructions for [XND] Nocturnal Animals (Continued)

## Mod Overview and Purpose
[XND] Nocturnal Animals enriches the immersive experience of RimWorld by introducing diverse circadian rhythms for animals. This modification allows certain animals to behave more accurately in accordance with their real-life counterparts. For example, foxes will now be nocturnal, sleeping during the day and active at night.

The mod introduces three different types of body clocks for animals:
- **Diurnal**: Awake during the day and asleep at night (vanilla behavior).
- **Nocturnal**: Awake during the night and asleep during the day.
- **Crepuscular**: Active during mornings and evenings, and resting during midday and midnight.

## Key Features and Systems
- **Localized Translations**: Available in English, Russian, and French.
- **In-Game Settings**: Allows players to customize the sleep patterns for all animals.
- **Cathemeral Type**: A flexible schedule for animals that don't precisely fit other categories.
- **Compatibility**: Works seamlessly with Vanilla Animals Expanded mods and is easy to integrate with other mods, although unpatched animals default to diurnal behavior.

## Coding Patterns and Conventions
- **Namespace Organization**: The mod code is organized under `NocturnalAnimals`, following RimWorld's modding convention.
- **Classes and Members**: Separation of concerns is maintained by organizing functionality into classes like `NocturnalAnimals`, `NocturnalAnimalsMod`, `NocturnalAnimalsSettings`, and others.
- **Settings Management**: Implemented in `NocturnalAnimalsSettings`, leveraging RimWorld's setting framework.

## XML Integration
XML files are utilized for defining patches for various animal categories:
- Patches are located in directories such as `Patches\LegacyArk.xml`, `Patches\Core\Races_Animal_BigCats.xml`, and more.
- These XML files describe adjustments necessary for integrating different animals with the mod's circadian rhythm system.

## Harmony Patching
- The mod uses the **Harmony Patch Library** to modify RimWorld's base game's behavior safely and dynamically.
- Patching is primarily focused on augmenting animal behaviors and circadian rhythm changes.

## Suggestions for Copilot
- **Automatic Patch Generation**: Create XML templates to help modders quickly add support for new animals by suggesting patterns based on existing XML files.
- **Helper Functions**: Suggest C# snippets to efficiently read and write settings utilizing `ExposeData` methodology.
- **Error Handling**: Recommend best practices and code snippets for ensuring smooth mod integration and error management, especially in scenarios involving adding and removing mods in save games.
- **Localization Support**: Propose string building patterns to ease adding new translations or enhancing existing ones.

By using the information provided in this file, developers and contributors can extend or modify the [XND] Nocturnal Animals mod effectively, following the established conventions and utilizing suggested practices for further improvements.

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

