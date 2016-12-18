using UnityEngine;
using System.Collections;

public class SpiderWalking : MonoBehaviour {
    public Animation anim;
    private bool dead = false;
	// Use this for initialization
	void Start () {
        anim.Play("walk");
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            anim.Play("walk");
        }
	}

    public void Die()
    {
        dead = true;
        anim.Play("death");
    }
}
