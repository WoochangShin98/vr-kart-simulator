using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRControllerTracker : MonoBehaviour
{
    OVRInput.Controller controllerR = OVRInput.Controller.RTouch; // RTouch for right controller
    OVRInput.Controller controllerL = OVRInput.Controller.LTouch; // LTouch for left controller
    bool first_trig = true;

    Vector3 position_init = Vector3.zero;
    Quaternion rotation_init = Quaternion.identity;

    void Update()
    {
        if((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f) && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f))
        {
            if(first_trig)
            {
                position_init = OVRInput.GetLocalControllerPosition(controllerL);
                rotation_init = OVRInput.GetLocalControllerRotation(controllerL);
                first_trig = false;
            }

            // Get position
            Vector3 positionL = OVRInput.GetLocalControllerPosition(controllerL);
            Vector3 positionR = OVRInput.GetLocalControllerPosition(controllerR);
            Debug.Log($"Different Position: {positionL}, {positionR}, {(positionL - positionR).y}");

            // Get rotation
            Quaternion rotationL = OVRInput.GetLocalControllerRotation(controllerL);
            Quaternion rotationR = OVRInput.GetLocalControllerRotation(controllerR);
            // Debug.Log($"Different Rotation: {rotation_init.eulerAngles}, {rotationL.eulerAngles}, {rotation_init.eulerAngles - rotationL.eulerAngles}");
        } 
        else 
        {
            first_trig = true;
        }
    }
}
