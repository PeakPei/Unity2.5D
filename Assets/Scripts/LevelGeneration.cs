using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGeneration : MonoBehaviour {

    public GameObject p0;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    public GameObject p9;
    public GameObject p10;
    public GameObject p11;
    public GameObject p12;
    public GameObject p13;
    public GameObject p14;
    public GameObject p15;
    public GameObject p16;
    public GameObject bossRoom;
    public GameObject platform;
    public GameObject startRoom;

    private List<GameObject> rooms;

    public int roomsN = 5;
    private int badDirection = -1;
    private int position = 0;
    private int prefab = 0;

    private float x = 0;
    private float y = 0;
    private float z = 0;
    private float x2 = 0;
    private float y2 = 0;
    private float z2 = 0;
    
    

	// Use this for initialization
	void Start () {
        ListPrefabs();
        GenerateRoom(roomsN);

	}
	
	// Update is called once per frame
	void Update () {
         

	}

    private void GenerateRoom(int number)
    {

        Instantiate(startRoom, new Vector3(x, y, z), Quaternion.identity);
        for (int i = 1; i < (number - 1); i++)
        {
            prefab = Random.Range(0, 17);
            position = Random.Range(0, 4);

            while (position == badDirection)
            {
                position = Random.Range(0, 4);
            }

            if (position == 0)
            {
                badDirection = 2;
                z += 24;
                z2 = z - 12;
                x2 = x;
            }
            if (position == 1)
            {
                badDirection = 3;
                x += 24;
                x2 = x - 12;
                z2 = z;
               
            }
            if (position == 2)
            {
                badDirection = 0;
                z += -24;
                z2 = z + 12;
                x2 = x;
            }
            if (position == 3)
            {
                badDirection = 1;
                x += -24;
                x2 = x + 12;
                z2 = z;

            }

            Instantiate(rooms[prefab], new Vector3(x, y, z), Quaternion.identity);
            Instantiate(platform, new Vector3(x2, y2, z2), Quaternion.identity);
        }

        position = Random.Range(0, 4);
        while (position == badDirection)
        {
            position = Random.Range(0, 4);
        }


        if (position == 0)
        {
            badDirection = 2;
            z += 24;
            z2 = z - 12;
            x2 = x;
        }
        if (position == 1)
        {
            badDirection = 3;
            x += 24;
            x2 = x - 12;
            z2 = z;

        }
        if (position == 2)
        {
            badDirection = 0;
            z += -24;
            z2 = z + 12;
            x2 = x;
        }
        if (position == 3)
        {
            badDirection = 1;
            x += -24;
            x2 = x + 12;
            z2 = z;

        }
        Instantiate(bossRoom, new Vector3(x, y, z), Quaternion.identity);
        Instantiate(platform, new Vector3(x2, y2, z2), Quaternion.identity);
    }

    private void ListPrefabs()
    {
        rooms = new List<GameObject>();

        rooms.Add(p0);
        rooms.Add(p1);
        rooms.Add(p2);
        rooms.Add(p3);
        rooms.Add(p4);
        rooms.Add(p5);
        rooms.Add(p6);
        rooms.Add(p7);
        rooms.Add(p8);
        rooms.Add(p9);
        rooms.Add(p10);
        rooms.Add(p11);
        rooms.Add(p12);
        rooms.Add(p13);
        rooms.Add(p14);
        rooms.Add(p15);
        rooms.Add(p16);
    }
}
