using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
    public GameObject explosion;
    private GameObject Player;

    private bool explode = true;
    public float speed = 10;

	void Start () {
        Player = GameObject.Find("Player");
	}
	

	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Player != null)
        {
            float dist = Vector3.Distance(Player.transform.position, transform.position);
            if (dist > 50)
            {
                this.gameObject.SetActive(false);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (explode == true)
            {
                Instantiate(explosion, transform.position, explosion.transform.rotation);
            }
            this.gameObject.SetActive(false);

        }
        if (other.tag == "Environment")
        {
            this.gameObject.SetActive(false);

        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public void setExplosion(bool value)
    {
        explode = value;
    }

    void Awake()
    {

        DontDestroyOnLoad(gameObject);

    }

}
