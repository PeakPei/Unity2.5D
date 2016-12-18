using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour {
    public GameObject particle;
    public AudioClip shooting;

    private List<GameObject> bullets;
    private BulletsManager bm;
    private AudioSource audio;
    private GameObject sp;

    private float playerX = Screen.width / 2;
    private float playerY = Screen.height * 0.3931f;
    private float a = 0;
    private float b = 0;
    private float rotation = 0;
    private float lastShotTime = -4;
    private float offlineTime = 0.5F;
    private int pooledAmount = 12;
    private float speed = 10;
    private bool explosion = false;
    private int weaponState = 1;




	void Start () {
        bm = GameObject.Find("Player").GetComponent<BulletsManager>();
        sp = GameObject.Find("ShootingPlace");
        bullets = new List<GameObject>();
        audio = GetComponent<AudioSource>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(particle);
            obj.SetActive(false);
            bullets.Add(obj);
            SetBulletsType(1);
        }

	}
	
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            if ((lastShotTime + offlineTime) < Time.time)
            {
                lastShotTime = Time.time;
                a = Input.mousePosition.x - playerX;
                b = Input.mousePosition.y - playerY;

                if (b > 0)
                {
                    rotation = 0 + Mathf.Atan(a / b) * Mathf.Rad2Deg;
                }
                else
                {
                    rotation = 180 + Mathf.Atan(a / b) * Mathf.Rad2Deg;
                }
                Fire();
            }
        }
	}

    private void Fire()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = sp.transform.position + new Vector3(0, 0f, 0);
                bullets[i].transform.rotation = Quaternion.Euler(0, rotation, 0);
                BulletBehaviour bb = bullets[i].gameObject.GetComponent<BulletBehaviour>();
                bb.setExplosion(explosion);
                bb.setSpeed(speed);
                bullets[i].SetActive(true);
                audio.PlayOneShot(shooting, 0.7F);
                break;
            }
        }
    }

    public void SetBulletsType(int type)
    {
        switch (type)
        {
            case 1:
                bm.SetDamage(1);
                speed = 15;
                offlineTime = 0.5F;
                explosion = false;
                weaponState = 1;
                break;
            case 2:
                bm.SetDamage(0.5F);
                speed = 10;
                offlineTime = 0.8F;
                explosion = true;
                weaponState = 2;
                break;
            case 3:
                bm.SetDamage(4F);
                speed = 10;
                offlineTime = 2F;
                explosion = false;
                weaponState = 3;
                break;
            case 4:
                bm.SetDamage(1F);
                speed = 25;
                offlineTime = 0.2F;
                explosion = false;
                weaponState = 4;
                break;
            default:
                bm.SetDamage(1);
                speed = 10;
                offlineTime = 0.5F;
                explosion = false;
                weaponState = 1;
                break;
        }
    }

    public int GetState()
    {
        return weaponState;
    }


}
