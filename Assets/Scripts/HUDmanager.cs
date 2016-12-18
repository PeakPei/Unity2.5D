using UnityEngine;
using System.Collections;

public class HUDmanager : MonoBehaviour {
    private GameManager gameManager;
    private PlayerMovement player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(50, 20, 300, 30), "HP: " + (player.getHealth()).ToString() + "/" + (player.getMaxHP().ToString()));
        //GUI.Label(new Rect(50, 20, 300, 30), "HP: " + player.transform.position.y);
        GUI.Label(new Rect(50, 50, 300, 30), "Score: " + (gameManager.getScore()).ToString());


    }

    
}
