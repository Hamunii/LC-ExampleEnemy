# Example Enemy

This repository contains the full source code for the Example Enemy for Lethal Company, including the Unity project which can be used to build its asset bundle. The guide part of this project can be found at https://lethal.wiki/dev/apis/lethallib/custom-enemies/overview.

## Setting Up The Project For Development

### Setup Script

After copying this repo for yourself, run [SETUP-PROJECT.py](/SETUP-PROJECT.py) from the command line like this: `python SETUP-PROJECT.py` (Or you can run it from your file manager on Linux). Note that you will have to have Python installed.  
- First, the setup project will copy DLL files over to `UnityProject/Assets/Plugins` directory so we can build our Asset Bundles without any errors.
    - Make sure have [HookGenPatcher](https://thunderstore.io/c/lethal-company/p/Evaisa/HookGenPatcher/) installed and have run the game at least once! This is needed for MMHOOK dll files.
- Second, it will ask you to paste a path to where it will copy over your mod files when you build your project. This is done by generating a `csproj.user` file with the path you inputted. After this, the setup process is done.
- If the script closes instanstly after opening it, it means it crashed. This is actually the reason why I told to run it from the command line. If you use Windows and can make this work, please open a pull request to fix this, thanks!
    - If the script still crashes after running from command line, try making sure you are running Python 3.

### Dependencies

You need to install the following dependencies for this mod to work in the game (these are not installed by the setup script):

- [LethalLib](https://thunderstore.io/c/lethal-company/p/Evaisa/LethalLib/) for registering and adding our enemy.
    - LethalLib depends on [HookGenPatcher](https://thunderstore.io/c/lethal-company/p/Evaisa/HookGenPatcher/).

And lastly, in the `Plugin` directory where our plugin code is, run `dotnet tool restore` on the commandline to install the rest of the dependencies.

 That should be all the required setup for this project, and now you can move to coding AI or making your own 3D models for your custom enemy. Good luck!

## Making The Mod Yours

### Thunderstore Packages

We have configured [ExampleEnemy.csproj](/Plugin/ExampleEnemy.csproj) to build a Thunderstore package to [/Plugin/Thunderstore/Packages/](/Plugin/Thunderstore/Packages/) using [tctl](https://github.com/thunderstore-io/thunderstore-cli/wiki) each time we make a release build of our mod. A release build can be done for example from the command line like this: `dotnet build -c release`. This will use configuration options from [thunderstore.toml](/Plugin/Thunderstore/thunderstore.toml), so configure it for your own mod! Do note that we have not included a way to upload your mod to thunderstore via tctl in this project.

### Renaming The Mod

Renaming a mod can easily break things if you don't update every instance of it. If you want to rename your mod, these are some of the things you need to worry about:
- rename `csproj` files
- rename solution file, with its references to your new csproj filename
- When renaming [ExampleEnemyAI.cs](/Plugin/src/ExampleEnemyAI.cs) and its class, make sure to compile your mod DLL and place it in `./UnityProject/Assets/Plugins` and add your new AI class as a component to your enemy prefab. If the class doesn't appear as an option, make sure your mod DLL doesn't have any errors in the Unity editor console. If your mod depends on other mods, also add their DLL files to the `Plugins` folder.
    - You might have to reapply all your configuration settings for the AI script. You need to be very careful to not miss a configuration option, as missing something can break the enemy's behavior or lead to errors.
- If your IDE complains about invalid references, try restarting it. If this does not fix it, you probably have forgotten to rename something.

> [!TIP]  
> You can use `Ctrl` + `Shift`+ `F` to search every file in both Visual Studio and Visual Studio Code. This can for example help you find every instance of `ExampleEnemy` inside files in the whole project. Do note however that this does not apply to filenames.  
> In Visual Studio, you can use `Ctrl` + `,` to search files by name. In Visual Studio Code you can use `Ctrl` + `Shift` + `P` and press `Backspace` to do the same.

## Credits

EvaisaDev - https://github.com/EvaisaDev/LethalCompanyUnityTemplate  
EvaisaDev - https://github.com/EvaisaDev/LethalLib  
Lordfirespeed - csproj.user template & reference tcli usage in LethalLib  
AlbinoGeek - Issue template & help with csproj  
...and everyone who has helped with this project!