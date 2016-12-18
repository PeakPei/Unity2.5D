using UnityEngine;
using System.Collections;

public class BossAnimations : MonoBehaviour {
    public Animation anim;
    private GameObject player;
    float dist = 100;

	void Start () {
	   


        player = GameObject.Find("Player");
	}
	
	void Update () {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > 5.1)
        {
            anim.Play("walk");
        }
        else
        {
            anim.Play("skill");
        }
	}
}
