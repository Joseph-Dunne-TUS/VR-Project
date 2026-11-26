README For Project Documentation and Report - A00327279 Joseph Dunne.

All labs completed from Learn with VR Unity Course.
Using what I have learned from the VR Tutorials I must create a small VR Tabletop Project.
# Report of Features:
## Locomotion:
- Can move freely moving the left thumbstick allowing the user walk around freely in the level.
- Can also teleport pushing the right thumbstick forward on any teleport anchor.
- Turn camera using the right thumbstick left and right, can 180 pushing backwards.

## Grabbable Objects:
- Grabbable board Pieces and a dice.
- Dice has Physics Material to simulate rolling the dice.

## Sockets:
- The board is covered in sockets to attach the different colour pieces too.
- For the Center pieces coloured sockets can only attached to the same coloured layer so you cannot piece other colour pieces on another colour.

## Audio and Haptics :
- When rolling the dice it makes sounds when shaken and also on activation
- Board pieces also have sound attached to them aswell.

## Activation Events:
- Can activate the dice to play a rolling sound to simulate shaking the dice.
- Buttons pressed hide and show UI elements based on what was presssed such as resetting the scene.
  
## Direct and ray interactors:
- Teleport rays allow the player to teleport on a surface and user can also change between them.
- Near-far interactors so the player can grab the pieces and dice.
- Poke interactors work for the UI Buttons aswell.
  
## User Interface:
- Start Scene with a simple introduction and basic explanation of the rules, hidden once all messages have been read.
- Pressing the reset scene button prompts the user with a button if they would like to reload the scene.
