# War in Middle Earth Game Editor

As the name suggests, this software aims to be an editor for the game War in Middle Earth 
by Synergistic Software & Melbourne House, © 1988. See https://en.wikipedia.org/wiki/War_in_Middle_Earth.

If you are an owner of a copy of the game, you can use its files to go through the various game resources 
(images, map tiles, animations, and texts). You can also view the whole map of Middle Earth as a single image and save it, 
which is actually not possible from the game itself. That’s the viewer part.

Now to the editor part in the Editor. You can edit WIME savegames! 
That’s a way to experiment with the game situation, especially military unit counts, and to cheat a bit.
So you can create an army of 1000 Gandalfs and send them against an enemy fortress 
or to a friendly city you want to stay undefeated.

## Installation

To install War in Middle Earth Game Editor, go to the Releases section of this repository and select a release. There you’ll find the WIMEInstall.exe file. Download it, run it, and follow the instructions on the screen.

Update Build 10 March 2019

- Added hard-coded palette lists to the Palette module.  Also added sprite sets for animation cycles and sprite colors. 
- Archive class separated from Game class.  Game class in process of being separated again.
- Various code cleaning throughout the files.
- Hard coded background to the final EXE file.
- Class organization.  Some information moved to GameData Module.

Bugs to fix:
- frmSpriteDraw:  File open error when selecting FRML4 in resource viewer and moving to another Sprite.  Appears all code closes the open FRMMTemp file but still get error.
- frmSpriteDraw.  Animate button does not activate animation of cycle 0.

