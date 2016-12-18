using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public Shader _norimas;

    private GameManager gameManager;
    private PlayerMovement player;
    private BulletsManager bm;
    private Shooting shooting;
    private Material material;
    
    public float health = 3; 
    public float score = 10;
    public float collisionDamage = 1F;

    private bool alive = true;
    private float lastHitTime = -4F;
    private float iframeTime = 0.3F;

    private float koef = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bm = GameObject.Find("Player").GetComponent<BulletsManager>();
        shooting = GameObject.Find("Player").GetComponent<Shooting>();
        material = new Material(_norimas);
	}
	
	// Update is called once per frame
	void Update () {
        Restart();
        if (!alive)
        {
            if (koef <= 1)
            {
                koef += 0.07f;
                material.SetFloat("_Koef", koef);
                material.SetColor("_Color", Color.red);
                GetComponent<Renderer>().enabled = true;
                GetComponent<Renderer>().material = material;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            player.changeHP(-collisionDamage);

        }
        else if (other.tag == "Bullet" && (lastHitTime +  iframeTime) < Time.time)
        {
            lastHitTime = Time.time;
            health -= bm.GetDamage();
            IsDead();
        }
        else if (other.tag == "Explosion")
        {
            lastHitTime = Time.time;
            health -= bm.GetBombsDamage();
            IsDead();
        }
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }

    void IsDead()
    {
        if(health <= 0 && alive){
            gameManager.changeScore(score);
            alive = false;
            
        }
    }
}
