# GitHub Copilot Instructions for Yayo's EndGame (Continued)

Welcome to the Yayo's EndGame (Continued) mod project! This mod aims to enhance the RimWorld experience by providing an epic journey through three biomes, collecting biome energy shards, building a planet energy core, constructing a planet energy teleporter, defending against a 15-day raid, and ultimately escaping to a new planet. Below are detailed guidelines and best practices to help you get started with modding using GitHub Copilot.

## Mod Overview and Purpose
Yayo's EndGame (Continued) is a mod that adds a compelling storyline to the RimWorld experience. The mod encourages players to travel through different biomes, extract energy shards, and build a teleporter to a new planet. The mod is designed to be compatible with biome add-on mods and includes a new ending text.

## Key Features and Systems
1. **Biome Energy Extraction**: Players need to extract 100 biome energy shards from each of three biomes. The type of shards generated depends on the working biome.
2. **Planet Energy Core**: A key material for building the teleporter, requiring three types of biome shards.
3. **Planet Energy Teleporter**: Players can build a device that allows them to teleport to a new planet.
4. **15-Day Raid Defense**: Players must defend against a raid.
5. **Escape**: Players can end the game with a new ending text.

## Coding Patterns and Conventions
To ensure consistency and maintainability, please follow these coding patterns and conventions:

1. **Mod Structure**: Organize your C# files into meaningful directories, such as `Buildings`, `Jobs`, `Settings`, etc.
2. **Naming Conventions**: Use PascalCase for class names and camelCase for method and variable names.
3. **Documentation**: Add XML comments to your code to describe the purpose and functionality of classes and methods.
4. **Error Handling**: Implement robust error handling and logging to help with debugging and troubleshooting.
5. **Code Reusability**: Utilize inheritance and interfaces to promote code reusability and maintainability.

## XML Integration
Yayo's EndGame (Continued) heavily relies on XML files to define game elements. Ensure that your XML files are well-structured and adhere to the following guidelines:

1. **File Structure**: Place XML files in the appropriate directories, such as `Defs` for definitions.
2. **Def Definitions**: Use the correct XML tags and attributes to define game elements, such as `ThingDef`, `JobDef`, and `WorkGiverDef`.
3. **Def References**: Use references to other definitions appropriately to avoid duplication and maintain consistency.
4. **Version Compatibility**: Ensure that your XML files are compatible with the target version of RimWorld (e.g., 1.7).

## Harmony Patching
Harmony patching is an essential part of modding in RimWorld. Follow these guidelines for effective patching:

1. **Patch Location**: Place Harmony patches in a dedicated file, such as `Patches.cs`.
2. **Patch Naming**: Use descriptive names for patches to indicate their purpose and target method.
3. **Patch Logic**: Implement the patch logic carefully to ensure that it does not interfere with the game's original functionality.
4. **Patch Testing**: Thoroughly test patches in different scenarios to ensure they work as expected.

## Suggestions for Copilot
To make the most of GitHub Copilot in this project, consider the following suggestions:

1. **Code Completion**: Use Copilot to complete code snippets and reduce boilerplate code.
2. **Documentation**: Utilize Copilot to generate XML comments for your code.
3. **Debugging**: Assist in debugging by suggesting potential fixes based on common issues.
4. **Optimization**: Help optimize code for performance and maintainability.
5. **Testing**: Provide suggestions for test cases to ensure code reliability.

## Getting Started
To begin modding with Yayo's EndGame (Continued), please follow these steps:

1. **Clone the Repository**: Clone the Yayo's EndGame (Continued) repository to your local machine.
2. **Set Up Your Environment**: Ensure you have the necessary tools installed, such as Visual Studio or Visual Studio Code, and the RimWorld development environment.
3. **Explore the Code**: Familiarize yourself with the existing codebase, including C# and XML files.
4. **Create a Branch**: Create a new branch for your changes to keep the main branch clean.
5. **Implement Your Features**: Start implementing your features or bug fixes.
6. **Test Your Changes**: Thoroughly test your changes in the game to ensure they work as expected.
7. **Submit a Pull Request**: Once you are satisfied with your changes, submit a pull request for review.

By following these guidelines and utilizing GitHub Copilot, you can contribute to the Yayo's EndGame (Continued) project and help enhance the RimWorld experience for players worldwide.

Happy modding!

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

