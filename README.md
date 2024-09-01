# 3D-TOP-DOWN-SHOOTER-GAME
3D-TOP-DOWN-SHOOTER-GAME


## Overview
This Unity 3D project is a top-down perspective shooter game where the player controls a character using the W, A, S, D / arrow keys. The character moves faster when the left shift key is held down and can shoot using the space bar.

## Features

### Character and Animations
- **Character & Animations:** The character and animations were sourced from Mixamo and integrated into the project. The character is set to Humanoid, and animation transitions are configured using the Animator.
- **Movement:** The character is controlled using W, A, S, D / arrow keys, and moves faster when the left shift key is held down.
- **Attack:** The character shoots with the space bar.

### Camera Control
- The camera is set up in a top-down perspective.

### Weapon and Bullet System
- **Weapon:** A weapon was added and positioned in the character's hand.
- **Bullet Firing System:** Implemented using object pooling. A bullet prefab was created, and the Muzzle Flash effect from the Asset Store was used for the firing effect.
- **Sound Effects:** A manually downloaded sound file was included in the project.

### Enemies and AI
- **Enemies:** Simple Capsule enemies were created and turned into Prefabs. Each enemy has a health bar.
- **Enemy AI:** Enemies are spawned randomly at certain points and intervals. They move towards the player using NavMesh after spawning.
- **Collision and Damage:** Enemies lose 50 health points upon collision with the player's bullet and die after two hits. The health reduction is reflected in the HP bar.
- **Health Bars:** Implemented using World Space canvas, ensuring they always face the camera.

### Map and Obstacles
- The entire surface was baked for NavMesh. Obstacles like buildings were added, forcing enemies to navigate around them.

### Score System
- **Score Tracking:** Score is updated and displayed on the screen using Canvas and TMP every time an enemy is killed.

### Assets
- **Asset Store:** Assets like the map and particle pack were downloaded and included in the project.

## Challenges and Solutions
Initially, I worked with a rifle and selected suitable animations for it. However, the rifle and animations were not compatible. I decided to switch to a pistol and found suitable animations, which I then integrated into the project.

## Debugging and Testing
All components of the project were tested using debug methods to ensure they functioned correctly.

## Setup and Run
To run this project, open the `GameScene` scene in the Unity Editor. The game will be playable with the specified controls.

---