// Copyright 1998-2016 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;
using System;

public class UnrealNode : ModuleRules
{
	public UnrealNode(TargetInfo Target)
	{
		PublicIncludePaths.Add("Runtime/Launch/Public");

		PrivateIncludePaths.Add("Runtime/Launch/Private");      // For LaunchEngineLoop.cpp include

        
        PrivateDependencyModuleNames.Add("Core");
		PrivateDependencyModuleNames.Add("Projects");
        
        //v8
        PrivateIncludePaths.AddRange(new string[]
        {
            Path.Combine(ThirdPartyPath, "v8", "include"),
            Path.Combine(ThirdPartyPath, "v8"),
        });

        LoadV8(Target);

        //libuv
        PrivateIncludePaths.AddRange(new string[]
        {
            Path.Combine(ThirdPartyPath, "libuv", "include"),
            Path.Combine(ThirdPartyPath, "libuv"),
        });


        LoadUV(Target);
    }


    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "ThirdParty")); }
    }


    public bool LoadV8(TargetInfo Target)
    {
        bool isLibrarySupported = false;

        if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))
        {
            isLibrarySupported = true;

            string LibrariesPath = Path.Combine(ThirdPartyPath, "v8", "lib");

            if (Target.Platform == UnrealTargetPlatform.Win64)
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Win64");
            }
            else
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Win32");
            }

            if (Target.Configuration == UnrealTargetConfiguration.Debug)
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Debug");
            }
            else
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Release");
            }
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "v8_base_0.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "v8_base_1.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "v8_base_2.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "v8_base_3.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "v8_libbase.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "v8_libplatform.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "v8_nosnapshot.lib"));

            Definitions.Add(string.Format("WITH_V8=1"));
            Definitions.Add(string.Format("WITH_V8_FAST_CALL=0"));
            Definitions.Add(string.Format("WITH_JSWEBSOCKET=1"));

           
        }
        else
        {

            Definitions.Add(string.Format("WITH_V8=0"));
            Definitions.Add(string.Format("WITH_V8_FAST_CALL=0"));
            Definitions.Add(string.Format("WITH_JSWEBSOCKET=0"));

        }
        return isLibrarySupported;
    }
    
    public bool LoadUV(TargetInfo Target)
    {

        bool isLibrarySupported = false;
        if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))
        {
            isLibrarySupported = true;

            string LibrariesPath = Path.Combine(ThirdPartyPath, "libuv", "lib");

            if (Target.Platform == UnrealTargetPlatform.Win64)
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Win64");
            }
            else
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Win32");
            }

            if (Target.Configuration == UnrealTargetConfiguration.Debug)
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Debug");
            }
            else
            {
                LibrariesPath = Path.Combine(LibrariesPath, "Release");
            }
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "libuv.lib"));

        }
        

        //Definitions.Add(string.Format("WITH_BOBS_MAGIC_BINDING={0}", isLibrarySupported ? 1 : 0));  

        return isLibrarySupported;
    }
}
