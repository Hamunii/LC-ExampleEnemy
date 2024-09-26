#!/usr/bin/env python
import os
import shutil
from subprocess import run
from inspect import getsourcefile
from contextlib import chdir

# This is an automated script for copying required dll files into this project.
# Supports both Windows and Linux.
#
# Also, this script got kinda out of hand towards the end. I won't waste more time on this though, it works anyways.
# Feel free to contribute to this script

class color:
   reset = '\033[0m'
   green = '\033[32m'
   yellow = '\033[93m'
   red = '\033[31m'
   lightblue = '\033[94m'
   lightcyan = '\033[96m'
   purple = '\033[35m'
   orange = '\033[33m'

def exitProgram():
   print(color.reset + 'Press Enter to close the program...')
   input()
   exit()

def copyDLLs(sourceDir: str, destinationDir: str, dllList: list) -> bool:
   if os.path.exists(fr'{sourceDir}'):
      for dllFile in dllList:
         shutil.copy2(f'{sourceDir}/{dllFile}', f'{destinationDir}/{dllFile}')
         print(f'Got: {dllFile}')
      return True
   return False

def main():
   # Locate us
   thisPath = os.path.dirname(os.path.realpath(getsourcefile(lambda:0)))
   gameDataRelative = 'Lethal Company_Data/Managed'

   # Locate the game's data folder
   gameFilesPath = None
   expectedGamePaths = ['C:/Program Files (x86)/Steam/steamapps/common/Lethal Company', f'{os.path.expanduser("~")}/.local/share/Steam/steamapps/common/Lethal Company']
   for path in expectedGamePaths:
      if os.path.exists(path):
         gameFilesPath = path
         break

   if gameFilesPath is None:
      print(color.yellow + "Could not locate Lethal Company game files!\nPlease paste the full path to 'Lethal Company':" + color.reset)
      userInputGamePath = input()
      if os.path.exists(userInputGamePath):
         gameFilesPath = userInputGamePath
      else:
         print(color.red + "Could not find location.")
         exitProgram()

   if (gameFilesPath[-1] == "/" or gameFilesPath[-1] == '\\'):
      userInputPath = f'{gameFilesPath}'

   print(color.green + f'Game data path found: {gameFilesPath}' + color.reset)

   # Make sure our Unity project still exists
   unityProjectPath = f'{thisPath}/UnityProject'
   unityPluginsRelative = 'Assets/Plugins'
   if not os.path.exists(unityProjectPath):
      print(color.yellow + f'Could not find Unity project at {unityProjectPath}! Paste the full path to your Unity project:' + color.reset)
      userInputUnityPath = input()
      if os.path.exists(userInputUnityPath):
         unityProjectPath = userInputUnityPath
      else:
         print(color.red + "Could not find location.")
         exitProgram()

   if not os.path.exists(f'{unityProjectPath}/{unityPluginsRelative}'):
      print(color.red + f"Your Unity Project does not have a {unityPluginsRelative} folder!\nMake sure your Unity Project is based on Lethal Company files.")
      exitProgram()
   print(color.lightblue + f'Unity Plugins path found: {unityProjectPath}/{unityPluginsRelative}' + color.reset)

   # Copying dlls for Unity project
   print('Copying game DLLs for Unity project:')
   neededPluginDllFiles =[
      "AmazingAssets.TerrainToMesh.dll",
      "ClientNetworkTransform.dll",
      "DissonanceVoip.dll",
      "Facepunch Transport for Netcode for GameObjects.dll",
      "Facepunch.Steamworks.Win64.dll",
      "Newtonsoft.Json.dll",
      "Assembly-CSharp-firstpass.dll"
   ]
   copyDLLs(f'{gameFilesPath}/{gameDataRelative}', f'{unityProjectPath}/{unityPluginsRelative}', neededPluginDllFiles)

   print(color.green + f'Done copying game DLLs to {unityProjectPath}/{unityPluginsRelative}!' + color.reset)

   #######################################################################################
   # This is non-game dll territory
   r2modmanPath = None
   expectedr2modmanPaths = [f'{os.path.expanduser("~")}/AppData/Roaming/r2modmanPlus-local/LethalCompany/profiles', f'{os.path.expanduser("~")}/.config/r2modmanPlus-local/LethalCompany/profiles']
   for path in expectedr2modmanPaths:
      if os.path.exists(path):
         r2modmanPath = path
         print(color.lightblue + f'r2modman Lethal Company path found: {r2modmanPath}' + color.reset)
         break

   neededCoreDlls = [
      "0Harmony20.dll",
      "0Harmony.dll",
      "BepInEx.dll",
   #  "BepInEx.Harmony.dll", Unity does not like this dll and causes a crash when building asset bundle
      "BepInEx.Preloader.dll",
      "HarmonyXInterop.dll",
      "Mono.Cecil.dll",
      "Mono.Cecil.Mdb.dll",
      "Mono.Cecil.Pdb.dll",
      "Mono.Cecil.Rocks.dll",
      "MonoMod.RuntimeDetour.dll",
      "MonoMod.Utils.dll"
   ]
   neededMMHOOKDlls = [
      "MMHOOK_AmazingAssets.TerrainToMesh.dll",
      "MMHOOK_Assembly-CSharp.dll",
      "MMHOOK_ClientNetworkTransform.dll",
      "MMHOOK_DissonanceVoip.dll",
      "MMHOOK_Facepunch.Steamworks.Win64.dll",
      "MMHOOK_Facepunch Transport for Netcode for GameObjects.dll"
   ]
   gotCoreFiles = None
   gotMMHOOKFiles = None
   if r2modmanPath is not None:
      for dir in os.listdir(r2modmanPath):
         if not gotCoreFiles:
            gotCoreFiles = copyDLLs(f'{r2modmanPath}/{dir}/BepInEx/core', f'{unityProjectPath}/{unityPluginsRelative}', neededCoreDlls)
         if not gotMMHOOKFiles:
            gotMMHOOKFiles = copyDLLs(f'{r2modmanPath}/{dir}/BepInEx/Plugins/MMHOOK', f'{unityProjectPath}/{unityPluginsRelative}', neededMMHOOKDlls)

   # Testing against non-r2modman installation if the mods exist there
   if not gotCoreFiles:
         gotCoreFiles = copyDLLs(f'{gameFilesPath}/BepInEx/core', f'{unityProjectPath}/{unityPluginsRelative}', neededCoreDlls)

   if not gotMMHOOKFiles:
         gotMMHOOKFiles = copyDLLs(f'{gameFilesPath}/BepInEx/Plugins/MMHOOK', f'{unityProjectPath}/{unityPluginsRelative}', neededMMHOOKDlls)
   if not gotMMHOOKFiles:
         gotMMHOOKFiles = copyDLLs(f'{gameFilesPath}/BepInEx/plugins/MMHOOK', f'{unityProjectPath}/{unityPluginsRelative}', neededMMHOOKDlls)

   if not gotCoreFiles:
      print(color.red + f"No BepInEx/core directory found! If you have no mod manager for Lethal Company, please install r2modman or setup BepInEx for Lethal Company manually.\n"
      f"{color.yellow}Or if you have a mod manager installed, please paste the full path to BepInEx folder: (otherwise press enter)" + color.reset)
      userInputBepInExPath = input()
      gotCoreFiles = copyDLLs(f'{userInputBepInExPath}/core', f'{unityProjectPath}/{unityPluginsRelative}', neededCoreDlls)
      if not gotCoreFiles:
         exitProgram()
      print(color.lightblue + f'BepInEx/core found: {userInputBepInExPath}/core' + color.reset)
      if not gotMMHOOKFiles:
         gotMMHOOKFiles = copyDLLs(f'{userInputBepInExPath}/Plugins/MMHOOK', f'{unityProjectPath}/{unityPluginsRelative}', neededMMHOOKDlls)

   if not gotMMHOOKFiles:
      print(color.red + f"No MMHOOK directory found! These DLL files are needed for our LethalLib dependency.\nPlease do the following to fix this:\n"
      "1) Install https://thunderstore.io/c/lethal-company/p/Evaisa/HookGenPatcher/\n"
      "2) Run the game once to generate the folder and its contents\n"
      "3) Run this script again\n"
      f"{color.yellow}Or if you have a separate installation of the game for testing which has the MMHOOK directory,\ninput the full path of the MMHOOK folder: (otherwise press enter)" + color.reset)
      userInputMMHOOKPath = input()
      if os.path.exists(userInputMMHOOKPath):
         print(color.lightblue + f'MMHOOK directory found: {userInputMMHOOKPath}' + color.reset)
         gotMMHOOKFiles = copyDLLs(f'{userInputMMHOOKPath}', f'{unityProjectPath}/{unityPluginsRelative}', neededMMHOOKDlls)

   if not gotMMHOOKFiles:
      print(color.red + "Could not find location.")
      exitProgram()

   #######################################################################################
   # Run `dotnet tool restore`

   print(color.lightblue + f'Part 1 of 3 complete!{color.purple}\nRunning `dotnet tool restore`')
   with chdir(f'{thisPath}/Plugin/'):
      try:
         print(color.lightcyan + f'We are in: {os.getcwd()}{color.purple}')
         run(["dotnet", "tool", "restore"]) 
      except:
         print(color.red + f'Error: failed to run command.')

   #######################################################################################
   # Generate .csproj.user file

   print(color.lightblue + f'Part 2 of 3 complete!{color.purple}\n> Next you will have to provide a path to where we will copy your mod files each time your build it.\n'
         
         f'{color.orange}Examples:\n'
         '     r2modman: /home/user/.config/r2modmanPlus-local/LethalCompany/profiles/testing/BepInEx/plugins\n'
         '     Game installation: /home/user/.local/share/Steam/steamapps/common/Lethal Company/BepInEx/plugins')
   print(color.lightcyan + f'Paste your path: ', end='')

   userInputPath = input()
   if not os.path.exists(userInputPath):
      print(color.red + 'Path not found!')
      exitProgram()

   if not (userInputPath[-1] == "/" and not userInputPath[-1] == '\\'):
      userInputPath = f'{userInputPath}/'

   userFile = f"""<?xml version="1.0" encoding="utf-8"?>
   <Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
      <!-- GENERATED BY SETUP-PROJECT.py -->
      <PropertyGroup>
         <!-- Automatically found or manually inputted game path -->
         <GameDirectory>{gameFilesPath}/</GameDirectory>
         <!-- The path you pasted when running the script -->
         <PluginsDirectory>{userInputPath}</PluginsDirectory>
      </PropertyGroup>

      <!-- Game Directories - Do Not Modify -->
      <PropertyGroup>
         <ManagedDirectory>$(GameDirectory)Lethal Company_Data/Managed/</ManagedDirectory>
      </PropertyGroup>
      
      <!-- Define Asset Bundles -->
      <ItemGroup>
         <AssetBundles Include="../../../UnityProject/Assets/ModAssets/ExampleContent/AssetBundles/*" />
         <AssetBundles Remove="../../../UnityProject/Assets/ModAssets/ExampleContent/AssetBundles/*.meta" />
         <AssetBundles Remove="../../../UnityProject/Assets/ModAssets/ExampleContent/AssetBundles/*.manifest" />
         <AssetBundles Remove="../../../UnityProject/Assets/ModAssets/ExampleContent/AssetBundles/AssetBundles" />
      </ItemGroup>
      
      <!-- Our mod files get copied over after NetcodePatcher has processed our DLL -->
      <Target Name="CopyToTestProfile" DependsOnTargets="NetcodePatch" AfterTargets="PostBuildEvent">
         <!-- Create DEV directory if it doesn't exist -->
         <MakeDir
            Directories="$(PluginsDirectory)$(AssemblyName)-DEV/"
            Condition="!Exists('$(PluginsDirectory)$(AssemblyName)-DEV/')"
         />
         <!-- Create Assets directory inside DEV if it doesn't exist -->
         <MakeDir
            Directories="$(PluginsDirectory)$(AssemblyName)-DEV/Assets/"
            Condition="!Exists('$(PluginsDirectory)$(AssemblyName)-DEV/Assets/')"
         />
         <!-- Copy the main DLL -->
         <Copy SourceFiles="$(TargetPath)" DestinationFolder="$(PluginsDirectory)$(AssemblyName)-DEV/"/>
         <!-- Copy all asset bundles to the Assets folder -->
         <Copy SourceFiles="@(AssetBundles)"
               DestinationFolder="$(PluginsDirectory)$(AssemblyName)-DEV/Assets/"/>
         <Exec Command="echo '[csproj.user] Mod files copied to $(PluginsDirectory)$(AssemblyName)-DEV/'" />
      </Target>
   </Project>"""

   fp = open(f'{thisPath}/Plugin/src/ExampleContent/ExampleContent.csproj.user', 'w')
   fp.write(userFile)
   fp.close()
   print(color.green + f'csproj.user file created at {thisPath}/Plugin/src/ExampleContent/ExampleContent.csproj.user!')

   print(color.lightblue + f'Project Setup Complete!{color.lightcyan}\n> You should now be able to build the C# project, including the Asset Bundle!')
   exitProgram()

if __name__ == "__main__":
   try:
      main()
   except Exception as exc:
      print(color.red + "Something went wrong, and the setup script crashed!" + color.reset)
      print(color.red + f"The error:\n{exc}" + color.reset)
      print(color.yellow + "Make sure you run this script from the command line, like so: python SETUP-SCRIPT.py" + color.reset)
      exitProgram()