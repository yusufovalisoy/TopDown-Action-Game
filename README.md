# Top-Down Action Game

A Unity-based top-down action game featuring player movement, projectile shooting, enemy AI, health UI, and level progression. This Unity project was developed for practice.

## Features

- WASD character movement
- Mouse-based aiming and shooting
- Projectile bullet system
- Enemy spider AI using NavMesh
- Player health system with UI health bar/text
- Enemy respawn system
- Level progression based on enemy kills
- Restart button on player death
- Level-up mechanic that increases bullet damage

## Technologies Used

- Unity
- C#
- NavMesh / AI Navigation
- TextMeshPro
- Unity UI System
- Animator / Animation Controller

## Gameplay Overview

The player controls a character in a top-down environment and fights enemy spiders using projectile-based combat.  
Enemies continuously respawn to maintain the target count, and the player progresses by defeating enemies.  
After reaching a specific kill threshold, the player levels up and gains increased bullet damage.

## Scripts Overview

### Player
Handles:
- health
- damage/death logic
- health UI updates

### PlayerMovement
Handles:
- WASD movement
- running
- jumping
- mouse-based rotation
- movement animation parameters

### PlayerCombat
Handles:
- shooting input
- bullet spawning
- attack animation trigger

### BulletManagement
Handles:
- bullet collision
- damage application to enemies
- bullet lifetime

### EnemySpider
Handles:
- NavMesh-based enemy movement
- player tracking
- contact damage to player

### EnemyHealth
Handles:
- enemy health
- death logic
- communication with EnemyManager

### EnemyManager
Handles:
- enemy spawning
- maintaining a fixed number of enemies
- delayed respawn system

### LevelManager
Handles:
- level-up logic
- bullet damage upgrade
- level completion UI

## Controls

- **W / A / S / D** → Move
- **Left Shift** → Run
- **Space** → Jump
- **Left Mouse Button** → Shoot
- **Mouse Movement** → Aim direction

## How to Run

1. Open the project in Unity.
2. Open the level1 scene from the `Scenes` folder.
3. Press Play in the Unity Editor.

## Notes

This project was developed as a gameplay-focused Unity project to practice:
- player controller systems
- enemy AI
- combat mechanics
- UI systems
- animation logic
- scene/game state management

## Future Improvements

- sound effects
- hit effects / muzzle flash
- improved enemy variety
- score system
- multiple levels
- pause menu
