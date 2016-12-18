using UnityEngine;
using System.Collections;

public class CameraMovement2 : MonoBehaviour {
    public GameObject playerObject;
    public Camera mainCamera;
    public float cameraOffsetY = 5.0F;
    public float cameraOffsetZ = -5.0F;

    void Update()
    {

        Vector3 cameraPosition = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + cameraOffsetY, playerObject.transform.position.z + cameraOffsetZ);
        mainCamera.transform.position = cameraPosition;
    }

    public void ResetCamera()
    {
        Vector3 cameraPosition = new Vector3(0, 0 + cameraOffsetY, 0 + cameraOffsetZ);
        mainCamera.transform.position = cameraPosition;
    }
}
