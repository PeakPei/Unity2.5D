using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private PlayerMovement player;

    private float score = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        Restart();
	}

    private void Restart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            player.RestartPlayer();
            score = 0;
        }
    }

    public float getScore()
    {
        return score;
    }

    public void changeScore(float score)
    {
        this.score += score;
    }
}
