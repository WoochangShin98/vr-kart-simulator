using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKart : MonoBehaviour
{
    public float maxSpeed = 150000f;           // 최대 속도
    public float acceleration = 50f;        // 초기 가속도
    public float slowAcceleration = 1f;    // 최대 속도 근처에서의 느린 가속도
    public float deceleration = 2f;        // 감속도
    public float rotationSpeed = 100f;     // 회전 속도
    public float currentSpeed = 0f;       // 현재 속도

    OVRInput.Controller controllerR = OVRInput.Controller.RTouch; // RTouch for right controller
    OVRInput.Controller controllerL = OVRInput.Controller.LTouch; // LTouch for left controller

    void Update()
    {
        var turn_angle = rotationSpeed * (currentSpeed / 25) * Time.deltaTime;

        Vector3 positionL = OVRInput.GetLocalControllerPosition(controllerL);
        Vector3 positionR = OVRInput.GetLocalControllerPosition(controllerR);

        Vector2 thumbstickValue = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        bool trig = ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f) && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f));

        if (Input.GetKey(KeyCode.S) || (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f))    // S 키를 누르면 감속 (후진)
        {
            // 후진 시 감속 (부정적 속도)
            currentSpeed -= acceleration * Time.deltaTime; // 후진 가속
            if (currentSpeed < -maxSpeed / 2) // 후진 최대 속도
                currentSpeed = -maxSpeed / 2; // 후진 최대 속도 제한

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            // A 키를 누르면 좌회전
            if (Input.GetKey(KeyCode.A) || ((positionL - positionR).y < -0.03 && trig) || (thumbstickValue.x < -0.3f))
            {
                transform.Rotate(Vector3.up, -turn_angle);
            }

            // D 키를 누르면 우회전
            if (Input.GetKey(KeyCode.D) || ((positionL - positionR).y > 0.03 && trig) || (thumbstickValue.x > 0.3f))
            {
                transform.Rotate(Vector3.up, turn_angle);
            }
        }
        else if (Input.GetKey(KeyCode.W) || (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.1f))   // W 키를 누르면 가속
        {
            // 현재 속도가 최대 속도에 도달하기 전까지는 일정한 가속
            if (true)
            {
                currentSpeed += acceleration * Time.deltaTime; // 일정하게 가속
                if (currentSpeed > maxSpeed)
                    currentSpeed = maxSpeed; // 최대 속도 제한
            }
            else
            {
                // 최대 속도에 도달한 후에는 느리게 증가
                currentSpeed += slowAcceleration * Time.deltaTime; 
                if (currentSpeed > maxSpeed)
                    currentSpeed = maxSpeed; // 최대 속도 제한
            }

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            // A 키를 누르면 좌회전
            if (Input.GetKey(KeyCode.A) || ((positionL - positionR).y < -0.03 && trig) || (thumbstickValue.x < -0.3f))
            {
                transform.Rotate(Vector3.up, -turn_angle);
            }

            // D 키를 누르면 우회전
            if (Input.GetKey(KeyCode.D) || ((positionL - positionR).y > 0.03 && trig) || (thumbstickValue.x > 0.3f))
            {
                transform.Rotate(Vector3.up, turn_angle);
            }
        }
        else
        {
            // 아무 키도 누르지 않았을 때 감속
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime; // 천천히 감속
                if (currentSpeed < 0)
                    currentSpeed = 0; // 음수로 떨어지지 않게
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += deceleration * Time.deltaTime; // 후진 시에도 천천히 멈추게
                if (currentSpeed > 0)
                    currentSpeed = 0; // 후진에서 속도가 양수로 올라가지 않게
            }

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            if (currentSpeed > 0)
            {
                // A 키를 누르면 좌회전
                if (Input.GetKey(KeyCode.A) || ((positionL - positionR).y < -0.03 && trig) || (thumbstickValue.x < -0.3f))
                {
                    transform.Rotate(Vector3.up, -turn_angle);
                }

                // D 키를 누르면 우회전
                if (Input.GetKey(KeyCode.D) || ((positionL - positionR).y > 0.03 && trig) || (thumbstickValue.x > 0.3f))
                {
                    transform.Rotate(Vector3.up, turn_angle);
                }
            }
            else if (currentSpeed < 0)
            {
                // A 키를 누르면 좌회전
                if (Input.GetKey(KeyCode.A) || ((positionL - positionR).y < -0.03 && trig) || (thumbstickValue.x < -0.3f))
                {
                    transform.Rotate(Vector3.up, -turn_angle);
                }

                // D 키를 누르면 우회전
                if (Input.GetKey(KeyCode.D) || ((positionL - positionR).y > 0.03 && trig) || (thumbstickValue.x > 0.3f))
                {
                    transform.Rotate(Vector3.up, turn_angle);
                }
            }
        }
    }
}
