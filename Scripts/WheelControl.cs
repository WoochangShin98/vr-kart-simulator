using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;

    public float steerAngle = 30f;  // 바퀴가 좌우로 회전할 최대 각도

    private float wheelSpinAngle = 100f;    // 바퀴의 회전 각도
    private float currentSteerAngle = 0f;   // 현재 조향 각도

    OVRInput.Controller controllerR = OVRInput.Controller.RTouch; // RTouch for right controller
    OVRInput.Controller controllerL = OVRInput.Controller.LTouch; // LTouch for left controller

    // 초기 위치 저장용 변수
    private Vector3 frontLeftInitialPos, frontRightInitialPos, rearLeftInitialPos, rearRightInitialPos;

    void Start()
    {
        // 바퀴의 초기 위치를 저장
        frontLeftInitialPos = frontLeftWheel.position;
        frontRightInitialPos = frontRightWheel.position;
        rearLeftInitialPos = rearLeftWheel.position;
        rearRightInitialPos = rearRightWheel.position;
    }

    void Update()
    {
        WheelRotation();
        HandleSteering();
    }

    // 바퀴의 회전만 처리 (X축 기준)
    void WheelRotation()
    {
        GameObject obj = GameObject.Find("BlueberrySodaKart");
        MoveKart moveKart = obj.GetComponent<MoveKart>();

        // 바퀴 회전 각도 증가
        wheelSpinAngle += (moveKart.currentSpeed * 10) * Time.deltaTime;

        // 각 바퀴가 자신의 X축을 기준으로 회전
        frontLeftWheel.localRotation = Quaternion.Euler(wheelSpinAngle, currentSteerAngle, 0f);
        frontRightWheel.localRotation = Quaternion.Euler(wheelSpinAngle, currentSteerAngle, 0f);
        rearLeftWheel.localRotation = Quaternion.Euler(wheelSpinAngle, 0f, 0f);
        rearRightWheel.localRotation = Quaternion.Euler(wheelSpinAngle, 0f, 0f);
    }

    // A, D 키 입력에 따른 바퀴 좌우 회전 처리
    void HandleSteering()
    {
        Vector3 positionL = OVRInput.GetLocalControllerPosition(controllerL);
        Vector3 positionR = OVRInput.GetLocalControllerPosition(controllerR);

        Vector2 thumbstickValue = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        bool trig = ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f) && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f));

        if (Input.GetKey(KeyCode.A) || ((positionL - positionR).y < -0.03 && trig) || (thumbstickValue.x < -0.3f) )
        {
            currentSteerAngle = Mathf.Lerp(currentSteerAngle, -steerAngle, Time.deltaTime * 5f);  // 왼쪽 회전
        }
        else if (Input.GetKey(KeyCode.D) || ((positionL - positionR).y > 0.03 && trig) || (thumbstickValue.x > 0.3f))
        {
            currentSteerAngle = Mathf.Lerp(currentSteerAngle, steerAngle, Time.deltaTime * 5f);   // 오른쪽 회전
        }
        else
        {
            currentSteerAngle = Mathf.Lerp(currentSteerAngle, 0f, Time.deltaTime * 5f);           // 키를 떼면 바퀴가 정면으로 돌아옴
        }
    }
}
