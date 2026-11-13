# VR Kart Simulator

Meta Quest 컨트롤러로 핸들과 페달을 조작해 카트를 운전하는 **VR 드라이빙 시뮬레이터**입니다.
VR/AR 수업 프로젝트 (2024 가을).

- **엔진:** Unity 2022.3.50f1
- **플랫폼:** Windows PC VR (Meta Quest + Quest Link / Air Link)
- **SDK:** Oculus Integration (OVRInput)
- **에셋:** Low Poly Road Pack (BrokenVector), Modular Karts Pack

## 실행 방법
1. Meta Quest를 PC에 연결하고 **Meta Quest Link** 앱을 실행합니다.
2. 저장소를 내려받고(Code → Download ZIP) `VR_Kart_Simulator/VR_Kart_Simulator.exe`를 실행합니다.

> `VR_Kart_Simulator` 폴더 안의 파일은 모두 같이 있어야 실행됩니다.

## 조작법

| 동작 | VR 컨트롤러 | 키보드 |
|---|---|---|
| 가속 | 오른손 검지 트리거 | `W` |
| 후진 / 감속 | 왼손 검지 트리거 | `S` |
| 조향 (핸들) | 양손 그립을 쥔 채 실제 핸들처럼 한쪽 손을 올리고 다른 손을 내리기 | `A` / `D` |
| 조향 (간편) | 오른손 썸스틱 좌우 | — |

아무 입력이 없으면 카트가 서서히 멈춥니다.

## 직접 작성한 스크립트 (`Scripts/`)

| 파일 | 역할 |
|---|---|
| `MoveKart.cs` | 가속·후진·감속, 속도에 비례한 회전 처리 |
| `RotateSteering.cs` | 입력에 따라 3D 핸들 모델을 좌우로 회전 |
| `WheelControl.cs` | 속도에 맞춰 바퀴를 굴리고 앞바퀴 조향각 적용 |
| `PedalControl.cs` | 트리거를 당기면 페달 모델이 눌리는 애니메이션 |
| `OVRControllerTracker.cs` | 양손 컨트롤러 위치를 추적하는 디버그용 스크립트 |

**핸들 조향 방식:** 양손 그립을 모두 쥐고 있을 때 두 컨트롤러의 높이 차이(`positionL.y - positionR.y`)가
±3 cm를 넘으면 그 방향으로 회전합니다.

## 폴더 구조
```
├─ README.md
├─ Scripts/                     직접 작성한 C# 스크립트 (원본)
└─ VR_Kart_Simulator/           Windows 빌드
   ├─ VR_Kart_Simulator.exe
   ├─ VR_Kart_Simulator_Data/
   ├─ MonoBleedingEdge/
   ├─ UnityPlayer.dll
   └─ UnityCrashHandler64.exe
```

## 참고
이 저장소에는 빌드 결과물과 직접 작성한 스크립트만 있습니다.
Unity 프로젝트 전체(Oculus SDK, 스토어 에셋 포함)는 용량과 라이선스 문제로 포함하지 않았습니다.
