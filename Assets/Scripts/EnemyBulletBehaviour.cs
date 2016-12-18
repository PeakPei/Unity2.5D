using UnityEngine;
using System.Collections;

public class EnemyBulletBehaviour : MonoBehaviour {
    private GameObject Player;

    public float speed = 10;
    public float damage = 0.5f;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        Vector3 targetDir = Player.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 360, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if (dist > 50)
        {
            Destroy(this.gameObject);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<PlayerMovement>().changeHP(-damage);
            Destroy(this.gameObject);

        }
    }
}
