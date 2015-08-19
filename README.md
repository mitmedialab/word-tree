# Word Tree
A Unity app designed to help childrne learn English letter-sound correspondence, sound blending, and sight word recognition.

## Build and Run
This tablet app was built and tested with Unity 4.6.2 and MonoDevelop 4.0.1.

## Image and Sound Credits
Images were found at ...

The speech used in this app was recorded by Jacqueline Kory Westlund. Other sounds were used from ... 

## Submodules
You don't need to pull in these submodules for the main project to run (the necessary scripts or dlls have been copied into the Assets/Plugins folder), but if you want their source, extra examples, prefabs, etc, then you can.

### TouchScript
[TouchScript] (https://github.com/TouchScript/TouchScript "TouchScript") makes it easy to detect and respond to touch events, such as taps and drags. You can build it from source following the instructions [here] (https://github.com/TouchScript/TouchScript/wiki/Building-TouchScript "Building TouchScript").

If you build from source, you can copy TouchScript/UnityPackages/TouchScript.Android to word-tree/Assets/ to access everything (like prefabs and examples) from within the Unity editor. That said, the only really important thing is the TouchScript dll in the Plugins folder (which is in the word-tree Assets/Plugins folder already).

Note that the MainCamera in the Unity scene needs a CameraLayer2D component attached. The camera layer is used to "see" which objects in the scene can be touched - see [Layers] (https://github.com/TouchScript/TouchScript/wiki/Layers "TouchScript Layers"). If you don't have a camera layer of some kind attached to the MainCamera, TouchScript will automatically add one, but the default is a CameraLayer that handles 3D objects and 3D colliders. Since WordTree is a 2D game, we need to use the CameraLayer2D, which is for 2D objects and 2D colliders. (Emphasizing this extra because it can cause needless headache.)

### LeanTween
[LeanTween] (https://github.com/dentedpixel/LeanTween/ "LeanTween git") is a library for animating sprites ([docs here] (http://dentedpixel.com/LeanTweenDocumentation/classes/LeanTween.html "LeanTween docs")).

If you pull in the submodule, you can get the examples, prefabs, etc. The necessary .cs file is in the word-tree Assets/Plugins folder already.

## TODO
- Auto-save the game after each level; keep track of which levels have been unlocked
- Remove the big red X and the 'slap' sound that occur when you get words wrong; make it more friendly!
 
