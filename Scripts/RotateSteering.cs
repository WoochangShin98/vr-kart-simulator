using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSteering : MonoBehaviour
{
    public Transform steeringWheel;

    public float rotationSpeed = 100.0f;  // 회전 속도
    private Quaternion initialRotation;  // 기본 위치 (-90, 90, -90)
    private Quaternion leftRotation;     // 좌회전 위치 (-150, 60, -125)
    private Quaternion rightRotation;    // 우회전 위치 (-30, 120, -55)

    OVRInput.Controller controllerR = OVRInput.Controller.RTouch; // RTouch for right controller
    OVRInput.Controller controllerL = OVRInput.Controller.LTouch; // LTouch for left controller

    void Start()
    {
        // 기본 상태, 좌회전, 우회전 회전값 설정
        initialRotation = Quaternion.Euler(-90, 90, -90);
        leftRotation = Quaternion.Euler(-120, 75, -107);
        rightRotation = Quaternion.Euler(-60, 105, -73);

        // 핸들의 초기 회전값 설정
        steeringWheel.localRotation = initialRotation;
    }

    void Update()
    {        
        var step = rotationSpeed * Time.deltaTime;

        Vector3 positionL = OVRInput.GetLocalControllerPosition(controllerL);
        Vector3 positionR = OVRInput.GetLocalControllerPosition(controllerR);

        Vector2 thumbstickValue = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        bool trig = ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f) && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f));

        // A 키를 누르면 좌회전
        if (Input.GetKey(KeyCode.A) || ((positionL - positionR).y < -0.03 && trig) || (thumbstickValue.x < -0.3f))
        {
            steeringWheel.localRotation = Quaternion.RotateTowards(steeringWheel.localRotation, leftRotation, step);
        }
        // D 키를 누르면 우회전
        else if (Input.GetKey(KeyCode.D) || ((positionL - positionR).y > 0.03 && trig) || (thumbstickValue.x > 0.3f))
        {
            steeringWheel.localRotation = Quaternion.RotateTowards(steeringWheel.localRotation, rightRotation, step);
        }
        else
        {
            // 기본 위치로 복귀
            steeringWheel.localRotation = Quaternion.RotateTowards(steeringWheel.localRotation, initialRotation, step*2);
        }
    }
}
