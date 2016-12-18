using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;
using System.Globalization;

public class PlayerMovement : MonoBehaviour {
    public GameObject player;
    public GameManager gm;
    public GameObject canvas;
    public Animation anim;

    public Vector3 startingPosition = new Vector3(0,3,0);

    private float maxHP = 5;
    private float HP = 5;

    public int playerSpeed = 6;
    private float rotation = 0;
    private bool change = false;

    private float lastHitTime = -5;
    private float iFramesTime = 1;

    private bool alive = true;
    private Rigidbody rb;

	void Start () {
        rb = player.GetComponent<Rigidbody>();
	}

    public void Update()
    {
        print(player.transform.position.y + " ");
        if (alive)
        {
            CalculateMovement();
        }
        if (player.transform.position.y < -5)// && alive)
        {
            canvas.SetActive(true);
            if (alive)
            {
                sendHighScore();
            }
            alive = false;
           
            
            
        }
	}


    public void CalculateMovement()
    {
        rotatePlayer(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D), 0f);
        rotatePlayer(!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D), 270f);
        rotatePlayer(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D), 180f);
        rotatePlayer(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D), 90f);

        rotatePlayer(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D), 45f);
        rotatePlayer(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D), 135f);
        rotatePlayer(!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D), 225f);
        rotatePlayer(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D), 315f);

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !change)
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
            anim.Play("walk");
        }
        else
        {
            anim.Play("free");
        }
        change = false;
    }

    private void rotatePlayer(bool inputs, float rotate)
    {
        if (inputs)
        {
            if (rotation != rotate)
            {
                float rotateAngle = rotate - rotation;
                rotation = rotate;
                transform.Rotate(0, rotateAngle, 0, Space.World);
                change = true;
            }
        }
    }

    public float getMaxHP()
    {
        return maxHP;
    }

    public void setMaxHP(float max)
    {
        maxHP = max;
    }

    public float getHealth()
    {
        return HP;
    }

    public void setHealth(float health)
    {
        HP = health;
    }

    public void changeHP(float health)
    {
        if (health > 0)
        {
            HP += health;
            if (HP > maxHP)
            {
                HP = maxHP;
            }
        }
        else
        {
            if ((Time.time - iFramesTime) > lastHitTime)
            {
                HP += health;
                lastHitTime = Time.time;
                if (HP <= 0)
                {
                    HP = 0;
                    alive = false;
                    canvas.SetActive(true);
                    sendHighScore();
                }
            }
        }
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void RestartPlayer()
    {
        player.transform.position = new Vector3(0, 1, 0);
        rb.velocity = new Vector3(0, 0, 0);
        maxHP = 5;
        HP = 5;
        alive = true;
        canvas.SetActive(false);
    }

    public void sendHighScore()
    {

        using (StreamWriter w = File.AppendText("Assets/Textfiles/highscores.txt"))
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            w.WriteLine(dateTime.ToString("yyyy-MM-dd") + "," + gm.getScore());
            w.Close();
        }
        

    }

    public void SetDefaultPosition()
    {
        transform.position = startingPosition;
    }
}

