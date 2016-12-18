using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Camera main;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UsualMovement();
    }


    void UsualMovement()
    {

        Vector3 target = player.transform.position;
        target.x = 0;
        target.y = 0;
        target.z += 2.5f;
        Vector3 newPosition = player.transform.position;
        newPosition.x = 0;
        newPosition.z += 1f;
        newPosition.y = 10;
        main.transform.position = newPosition;
        main.transform.LookAt(target);
    }
}
