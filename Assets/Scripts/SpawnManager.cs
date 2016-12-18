using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
    public GameObject enemyFab;

    private GameObject Player;

    public float sRange = 15;
    private bool spawned = false;
    private float rrTime = -4;

	void Start () {
        Player = GameObject.Find("Player");
	}
	
	void Update () {
        if (Player != null)
        {
            float dist = Vector3.Distance(Player.transform.position, transform.position);
            if (dist < sRange && !spawned)
            {
                enemyFab.transform.localEulerAngles = new Vector3(0, 180, 0);
                Instantiate(enemyFab, transform.position, enemyFab.transform.rotation);
                spawned = true;

            }
            Restart();
        }
	}

    private void Restart()
    {
        if (Input.GetKey(KeyCode.R) && rrTime + 2 < Time.time)
        {
            rrTime = Time.time;
            spawned = false;
        }
    }
}
