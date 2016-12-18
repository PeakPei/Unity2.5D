using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {
    public AudioClip explosion;

    private GameObject Player;
    private AudioSource audio;

    private float hitTime;
    private float currentTime = 0;

    void Start()
    {
        hitTime = Time.time;
        Player = GameObject.Find("Player");
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(explosion, 0.5F);
    }

    void Update()
    {
        currentTime = Time.time;
        this.transform.localScale += new Vector3(0.05F, 0.05f, 0.05F);
        if (hitTime + 1 < currentTime)
        {
            Destroy(this.gameObject);
        }
    }

}
