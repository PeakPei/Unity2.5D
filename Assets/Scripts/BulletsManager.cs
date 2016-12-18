using UnityEngine;
using System.Collections;

public class BulletsManager : MonoBehaviour {
    private float damage = 1;
    private float bombsDamage = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float GetDamage()
    {
        return damage;
    }

    public float GetBombsDamage()
    {
        return bombsDamage;
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    public void SetBombDamage(float dmg)
    {
        bombsDamage = dmg;
    }
}
