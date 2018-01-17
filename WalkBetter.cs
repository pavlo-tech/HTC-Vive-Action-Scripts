using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBetter : MonoBehaviour
{
    private SteamVR_Controller.Device LeftController;

    void Awake()
    {
        LeftController = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestLeft));
    }
    
	// Update is called once per frame
	void Update ()
    {
        Vector2 touchpadVector = LeftController.GetAxis();
        touchpadVector.Normalize();
        touchpadVector /= 50;

        float controllerRotation = -1 * LeftController.transform.rot.y * Mathf.PI;

        float x = touchpadVector.x * Mathf.Cos(controllerRotation) - touchpadVector.y * Mathf.Sin(controllerRotation);
        float z = touchpadVector.x * Mathf.Sin(controllerRotation) + touchpadVector.y * Mathf.Cos(controllerRotation);

        gameObject.transform.position += new Vector3(x, 0, z);
    }
}
