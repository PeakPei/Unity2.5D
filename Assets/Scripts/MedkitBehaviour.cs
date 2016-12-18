using UnityEngine;
using System.Collections;

public class MedkitBehaviour : MonoBehaviour {
    public GameObject shroom;
    
    private Collider col;
    private PlayerMovement player;


    private bool used = false;

	void Start () {
        col = GetComponent<BoxCollider>();
        col.enabled = true;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            col.enabled = true;
            used = false;
            shroom.SetActive(true);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!used)
            {
                player.changeHP(2);
                col.enabled = false;
                used = true;
                shroom.SetActive(false);
            }
        }

    }
}
