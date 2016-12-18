using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
   
    private GameObject obj;
    private PlayerMovement player;
    private CameraMovement2 camera;
    private AsyncOperation async;

    public int level = 2;
    public Vector3 startingPosition = new Vector3(-24, 0.1f, -99);
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraMovement2>();
        obj = GameObject.Find("SpawnManager 3");
        startingPosition = obj.transform.position;
        transform.position = startingPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SetDefaultPosition();
            camera.ResetCamera();
            ClickAsync(level);
        }

    }

    public void ClickAsync(int level)
    {
        StartCoroutine(LoadLevel(level));
    }


    IEnumerator LoadLevel(int level)
    {
        async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
