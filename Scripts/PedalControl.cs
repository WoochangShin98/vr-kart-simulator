using UnityEngine;

public class PedalController : MonoBehaviour
{
    public Transform pedal; // 페달 객체의 Transform
    public Vector3 pressedPosition; // 페달이 눌렸을 때의 위치 (Y와 Z 값 변경)
    public Vector3 defaultPosition; // 페달이 원래 위치
    public float pedalMoveSpeed = 5f; // 페달이 움직이는 속도

    public KeyCode keyToCheck = KeyCode.W;
    public OVRInput.Axis1D pedalKey = OVRInput.Axis1D.SecondaryIndexTrigger; // 페달을 밟는 키 (사용자가 지정 가능)

    private bool isPressingPedal = false; // 페달을 밟고 있는지 여부

    void Start()
    {
        // 페달의 기본 위치 설정
        defaultPosition = pedal.localPosition;
    }

    void Update()
    {
        // 사용자가 지정한 키 입력 체크
        if (Input.GetKey(keyToCheck) || (OVRInput.Get(pedalKey) > 0.1f))
        {
            isPressingPedal = true;
        }
        else
        {
            isPressingPedal = false;
        }

        UpdatePedalMovement(); // 페달 움직임 업데이트
    }

    void UpdatePedalMovement()
    {
        if (isPressingPedal)
        {
            // 페달을 밟고 있을 때 pressedPosition으로 이동
            pedal.localPosition = Vector3.Lerp(pedal.localPosition, pressedPosition, Time.deltaTime * pedalMoveSpeed);
        }
        else
        {
            // 페달을 밟지 않으면 defaultPosition으로 이동
            pedal.localPosition = Vector3.Lerp(pedal.localPosition, defaultPosition, Time.deltaTime * pedalMoveSpeed);
        }
    }
}
