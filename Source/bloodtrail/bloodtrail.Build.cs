// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class bloodtrail : ModuleRules
{
	public bloodtrail(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"bloodtrail",
			"bloodtrail/Variant_Platforming",
			"bloodtrail/Variant_Platforming/Animation",
			"bloodtrail/Variant_Combat",
			"bloodtrail/Variant_Combat/AI",
			"bloodtrail/Variant_Combat/Animation",
			"bloodtrail/Variant_Combat/Gameplay",
			"bloodtrail/Variant_Combat/Interfaces",
			"bloodtrail/Variant_Combat/UI",
			"bloodtrail/Variant_SideScrolling",
			"bloodtrail/Variant_SideScrolling/AI",
			"bloodtrail/Variant_SideScrolling/Gameplay",
			"bloodtrail/Variant_SideScrolling/Interfaces",
			"bloodtrail/Variant_SideScrolling/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
