using UnityEngine;
using System.Collections;

public class WeaponPickUp : MonoBehaviour {
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;

    private Shooting player;
    private GameManager gameManager;
    private GameObject obj;

    public int weaponType;
    public float height = 15f;
    public bool destroy = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Shooting>();
	}
	
	// Update is called once per frame
	void Update () {
        if (destroy)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int type = player.GetState();
            player.SetBulletsType(weaponType);
            switch (type)
            {
                case 1:
                    obj = (GameObject)Instantiate(w1);
                    obj.transform.position = transform.position + new Vector3(0, height, 0);
                    break;
                case 2:
                    obj = (GameObject)Instantiate(w2);
                    obj.transform.position = transform.position + new Vector3(0, height, 0);
                    break;
                case 3:
                    obj = (GameObject)Instantiate(w3);
                    obj.transform.position = transform.position + new Vector3(0, height, 0);
                    break;
                case 4:
                    obj = (GameObject)Instantiate(w4);
                    obj.transform.position = transform.position + new Vector3(0, height, 0);
                    break;
                default:
                    obj = (GameObject)Instantiate(w1);
                    obj.transform.position = transform.position + new Vector3(0, height, 0);
                    break;
            }

            destroy = true;
           
        }

    }
}
