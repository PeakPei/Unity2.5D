using UnityEngine;
using System.Collections;

public class TransformTowards : MonoBehaviour {
    private GameObject player;

    public float speed = 5;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            Vector3 targetDir = player.transform.position - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
	}
}
