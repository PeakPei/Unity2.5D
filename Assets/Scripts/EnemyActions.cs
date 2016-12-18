using UnityEngine;
using System.Collections;

public class EnemyActions : MonoBehaviour {
    public GameObject eBullet;
    public AudioClip shooting;

    private AudioSource audio;
    private Transform target;
    private GameObject Player;

    public float speed = 1;
    public float nRange = 7;
    public float shRange = 5;
    public float stRange = 1.5f;
    public float delayBS = 1F;

    private float dist;
    private float step;
    private float lastShotTime = -5F;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        audio = GetComponent<AudioSource>();
        target = Player.transform;
	}


    void Update()
    {
        IsDead();
        Movements();


    }

    private void IsDead()
    {
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void Movements()
    {
        if (Player != null)
        {
            dist = Vector3.Distance(Player.transform.position, transform.position);

            if (dist < nRange && dist > stRange)
            {
                step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            }
            if (dist < shRange && (lastShotTime + delayBS) < Time.time)
            {
                lastShotTime = Time.time;
                Instantiate(eBullet, transform.position, Quaternion.identity);
                audio.PlayOneShot(shooting, 0.7F);
            }
        }
    }
}
