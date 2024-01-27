#!/usr/bin/env python
import os
import json
from zipfile import ZipFile
from inspect import getsourcefile


thisPath = os.path.dirname(os.path.realpath(getsourcefile(lambda:0)))
metadataFile = open(f'{thisPath}/manifest.json')
metadata = json.load(metadataFile)
metadataFile.close()
releasePath = f'{thisPath}/Packages/{metadata['name']}{metadata['version_number']}.zip'

class color:
   reset = '\033[0m'
   green = '\033[32m'
   yellow = '\033[93m'
   red = '\033[31m'
   lightblue = '\033[94m'
   lightcyan = '\033[96m'

def exitProgram():
   print(color.reset + 'Press Enter to close the program...')
   input()
   exit()

if not os.path.exists(f'{thisPath}/Packages'):
   print(f'Directory {thisPath}/Packages not found!')
   exitProgram()

if not os.path.exists(f'{os.path.join(thisPath, os.pardir)}/bin/Release/netstandard2.1/{metadata['name']}.dll'):
   print(color.red + 'No DLL file built with release found!\n'
         f'{color.yellow}To fix this, build the project with release configuration.')
   exitProgram()

print(color.yellow + 'NOTE: This Script only copies files into a Zip, it does not build the mod DLL itself!\n'
      f'{color.reset}The DLL file for the package will be copied from "../bin/Release/netstandard2.1/"' + color.reset)

if os.path.exists(releasePath):
    print(color.red + f'A release with the version number {metadata['version_number']} already exists!\n'
          'Remember to update your manifest and changelog!')
    exit()

print(color.green + 'Making the zip package...')

with ZipFile(releasePath, 'w') as zip_object:
   # Adding files that need to be zipped
   zip_object.write(f'{os.path.join(os.path.join(thisPath, os.pardir), os.pardir)}/UnityProject/AssetBundles/StandaloneWindows/modassets', f'/modassets')
   zip_object.write(f'{os.path.join(thisPath, os.pardir)}/bin/Release/netstandard2.1/{metadata['name']}.dll', f'/{metadata['name']}.dll')
   zip_object.write(f'{thisPath}/icon.png', '/icon.png')
   zip_object.write(f'{thisPath}/README.md', '/README.md')
   zip_object.write(f'{thisPath}/CHANGELOG.md', '/CHANGELOG.md')
   zip_object.write(f'{thisPath}/manifest.json', '/manifest.json')

if os.path.exists(releasePath):
   print(color.lightblue + f'Zip package created at {releasePath}')
else:
   print(color.red + f'Zip package could not be created at "{releasePath}"!')

exitProgram()