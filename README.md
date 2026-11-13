# VR Kart Simulator

A **VR driving simulator** where you drive a kart by operating the steering wheel and pedals with Meta Quest controllers.
Course project for a VR/AR class (Fall 2024).

- **Engine:** Unity 2022.3.50f1
- **Platform:** Windows PC VR (Meta Quest + Quest Link / Air Link)
- **SDK:** Oculus Integration (OVRInput)
- **Assets:** Low Poly Road Pack (BrokenVector), Modular Karts Pack

## How to Run
1. Connect your Meta Quest to the PC and launch the **Meta Quest Link** app.
2. Download this repository (Code → Download ZIP) and run `VR_Kart_Simulator/VR_Kart_Simulator.exe`.

> All files inside the `VR_Kart_Simulator` folder must stay together for the game to run.

## Controls

| Action | VR Controller | Keyboard |
|---|---|---|
| Accelerate | Right index trigger | `W` |
| Reverse / Brake | Left index trigger | `S` |
| Steer (wheel) | Hold both grip buttons and raise one hand while lowering the other, like turning a real steering wheel | `A` / `D` |
| Steer (simple) | Right thumbstick left/right | — |

With no input, the kart gradually slows to a stop.

## Custom Scripts (`Scripts/`)

| File | Description |
|---|---|
| `MoveKart.cs` | Handles acceleration, reverse, deceleration, and speed-proportional turning |
| `RotateSteering.cs` | Rotates the 3D steering wheel model left/right based on input |
| `WheelControl.cs` | Spins the wheels according to speed and applies the front-wheel steering angle |
| `PedalControl.cs` | Animates the pedal model being pressed when the trigger is pulled |
| `OVRControllerTracker.cs` | Debug script that tracks the positions of both controllers |

**Steering mechanism:** While both grip buttons are held, the kart turns in the corresponding direction when the
height difference between the two controllers (`positionL.y - positionR.y`) exceeds ±3 cm.

## Project Structure
```
├─ README.md
├─ Scripts/                     Custom C# scripts (source)
└─ VR_Kart_Simulator/           Windows build
   ├─ VR_Kart_Simulator.exe
   ├─ VR_Kart_Simulator_Data/
   ├─ MonoBleedingEdge/
   ├─ UnityPlayer.dll
   └─ UnityCrashHandler64.exe
```

## Notes
This repository contains only the build output and the custom scripts.
The full Unity project (including the Oculus SDK and Asset Store assets) is not included due to size and licensing restrictions.
