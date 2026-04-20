# VR Rhythm Game Prototype

## Overview
This repository contains a Virtual Reality rhythm game prototype developed in Unity. Inspired by fast-paced rhythm action games, the project features dynamic block spawning, progressive difficulty scaling, and a VR-optimized physical interaction system relying on the Unity XR Interaction Toolkit.

## Key Features

### Dynamic Block Spawning
The `BlockSpawner` system automatically generates sequence targets (blocks) for the player.
* **Configurable Physical Bounds:** The spawner utilizes exposed inspector parameters to define the comfortable play area (e.g., waist to head height, chest to arm-span width).
* **Crossover Mechanics:** Includes randomized logic allowing targets to cross over to opposite sides, increasing cognitive load and gameplay variety.
* **Progressive Difficulty:** Utilizes Unity Coroutines to smoothly decrease the spawn interval over time, naturally ramping up the game's intensity without frame-rate dependent `Update` loops.

### Interaction & Collision System
The `BeatBlock` script manages the lifecycle and movement of individual targets.
* **Tag-based Verification:** The system checks collision tags to ensure the correct hand ("LeftHand" or "RightHand") destroys the corresponding colored block (e.g., Red or Blue).
* **Automated Cleanup:** Targets that bypass the player are automatically destroyed upon crossing a specific Z-axis threshold to ensure optimal memory management and maintain high frame rates.

### Game State Management
The `GameManager` script serves as the central hub for game state and user interface coordination.
* **Real-time Scoring:** Integrates with TextMeshPro to provide immediate visual feedback upon successful interactions.
* **VR-Safe Pause System:** Leverages the new Unity Input System to detect controller events (such as the Primary Button). When triggered, it selectively pauses the game world physics (`Time.timeScale = 0`) and summons a Pause UI. This approach safely halts incoming targets without freezing the user's headset or hand tracking, preventing VR motion sickness.

## Technical Specifications
* **Engine:** Unity 3D
* **Frameworks:** XR Interaction Toolkit, Unity Input System
* **UI:** TextMeshPro (TMP)
* **Version Control:** Git with Git Large File Storage (LFS) configured for heavy assets (3D models, textures, audio).

## Repository Setup Instructions

Due to the inclusion of 3D assets and Unity-specific files, this repository utilizes Git LFS. 

1. Ensure you have Git LFS installed on your local machine.
   ```bash
   git lfs install
   ```
2. Clone the repository.
   ```bash
   git clone https://github.com/Raunakg2005/VR-beat-box.git
   ```
3. Open the project folder `lab ca` using the Unity Hub.
4. Ensure the XR Interaction Toolkit and Input System packages are resolved in the Unity Package Manager.

## Scene Configuration
To test the environment properly in Unity:
* Assign the `ScoreText` UI element to the GameManager.
* Assign the `PauseMenuUI` Canvas to the GameManager to enable toggling.
* Bind the Primary Button (e.g., A/X) from the XR Controller to the `toggleMenuAction` parameter in the GameManager.
* Ensure player hands possess Colliders and Rigidbody components (set to Kinematic) tagged appropriately as "LeftHand" and "RightHand".