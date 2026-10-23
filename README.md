| Animation and audio | Unity Animator, animation events, and AudioSource |

Package dependencies are declared in [`Packages/manifest.json`](Packages/manifest.json), and the exact editor version is recorded in [`ProjectSettings/ProjectVersion.txt`](ProjectSettings/ProjectVersion.txt).

## Open and run locally

### Requirements

- Unity Hub.
- Unity Editor **2023.2.9f1**, preferably matching the version recorded by the project.
- A keyboard for gameplay.
- The Unity build-support module for any platform you intend to build.

### Setup

1. Clone or download this repository.
2. In Unity Hub, select **Add project from disk** and choose the project root containing `Assets`, `Packages`, and `ProjectSettings`.
3. Open the project with Unity 2023.2.9f1.
4. Allow Unity to import assets and resolve packages.
5. Open `Assets/Scenes 1/MainMenu.unity`.
6. Enter Play Mode and start a game through the menu.

Start with the main menu so that the selected mode is initialized before the gameplay scene loads.

## Build the project

1. Open **File > Build Settings** in Unity.
2. Confirm that these scenes are enabled in this order:
   - `Assets/Scenes 1/MainMenu.unity`
   - `Assets/Scenes 1/GamePlay.unity`
3. Select your target platform and install its build-support module through Unity Hub if necessary.
4. Select **Switch Platform** if changing targets.
5. Choose **Build** or **Build And Run** and select an output folder.

These two scenes are already enabled in the repository's `EditorBuildSettings.asset`. For a browser build, select WebGL and use the corresponding Unity build-support module. The published game is available through the itch.io link above.

## Project structure

```text
Assets/
  Scripts/                    Core gameplay, input, scoring, timer, themes, and audio
  Scenes 1/                   MainMenu, GamePlay, additional scenes, and Manager.cs
  Animations/                 Balloon animations and colored balloon prefabs
  Balloons/                   Balloon-related assets
  [REDSEN] Free BGM/           Bundled background-music assets
  Quantum Tek/                Quantum UI assets, scripts, prefabs, and demo scenes
  TextMesh Pro/               TextMeshPro resources and example content
Packages/
  manifest.json               Unity package dependencies
ProjectSettings/              Editor version, build scenes, and project configuration
```

`TimerMode.unity` and several demo scenes are also present, but the configured build uses `MainMenu` and `GamePlay`. Timed gameplay is selected through mode state in the shared gameplay scene.

## How the code works

| Script | Responsibility |
| --- | --- |
| `Assets/Scenes 1/Manager.cs` | Stores the selected mode, loads scenes, and handles pause, resume, restart, menu navigation, and application exit. |
| `Assets/Scripts/BalloonSpawnerScript.cs` | Instantiates balloon prefabs, chooses words and positions, tracks active balloons, and compares submitted input against their words. |
| `Assets/Scripts/BalloonScript.cs` | Applies upward force, displays the balloon word, triggers popping, and exposes animation-event callbacks. |
| `Assets/Scripts/InputManager.cs` | Keeps the TextMeshPro input field focused, handles submission, normalizes input to lowercase, and clears the field. |
| `Assets/Scripts/ScoreManager.cs` | Tracks popped balloons and remaining lives, detects missed balloons, switches the mode-specific HUD, and displays game-over results. |
| `Assets/Scripts/TimerScript.cs` | Runs the 60-second countdown and ends the timed round. |
| `Assets/Scripts/ModeScript.cs` | Switches light/dark visuals and updates the interface colors. |
| `Assets/Scripts/soundEffectScript.cs` | Plays pop, click, and game-over audio clips. |
| `Assets/Scripts/Balloon.cs` | Randomizes a balloon sprite and sets upward velocity for decorative balloons. |
| `Assets/Scripts/MenuSpawner.cs` | Repositions decorative balloons when they leave the menu's trigger area. |

### Gameplay flow

```text
Main menu -> Select mode -> Load GamePlay
                                |
                         Spawn word balloons
                                |
                        Type word + press Enter
                                |
                      Match -> Pop -> Update count
                                |
                 Timer expires / all lives are lost
                                |
                      Show score and game-over UI
                                |
                       Restart or return to menu
```

Scripts locate several shared components through GameObject tags, including `Manager`, `Spawner`, `ScoreManager`, `SoundEffect`, and `Music`. Prefabs and scenes also provide serialized references to UI elements, audio clips, sprites, and animation components. Preserve these references when editing scenes or replacing assets.

## Customization

- **Vocabulary:** Edit the `randomWords` list in `BalloonSpawnerScript.cs`. The spawn logic currently filters out words longer than eight characters.
- **Round length:** Change `currentTime` in `TimerScript.cs` (default: 60 seconds).
- **Lives:** Review the initial lives value, `setLives()`, and the life-balloon references in `ScoreManager.cs` together (default: five lives).
- **Scoring:** Adjust the multiplier in `ScoreManager.setScore()` (default: five points per balloon).
- **Balloon movement:** Adjust the `low` and `high` force bounds and `speedChange()` in `BalloonScript.cs`.
- **Spawn behavior:** Adjust the delay range, horizontal bounds, and minimum spacing in `BalloonSpawnerScript.cs`.
- **Visuals and sound:** Replace serialized sprites, prefabs, audio clips, and theme references in the Unity Inspector.

## Current implementation notes

The following details are useful when extending or debugging the project:

- Difficulty-related methods exist, but `Manager.ChangeDifficulty()` is empty and the spawner's stored difficulty value does not currently control gameplay.
- Balloon spawning attempts to avoid duplicate active words. The retry flag is not reset inside the retry loop, so selecting a duplicate can leave that loop running indefinitely; review this logic before extending the vocabulary or spawn system.
- The movement force bounds are static and increase during spawning. They are not explicitly reset when restarting a round.
- The countdown display uses the seconds component (`currentTime % 60`), so its initial display can differ from a conventional full-duration countdown.
- No persistent high-score storage is implemented in the core gameplay scripts.

## Included assets

The repository includes Quantum Tek Quantum UI content, TextMeshPro resources/examples, and a `[REDSEN] Free BGM` asset folder. Refer to the respective asset documentation and licenses for attribution and reuse terms.

---

**[Play Type 'n Pop](https://hananaasif.itch.io/type-n-pop)**
