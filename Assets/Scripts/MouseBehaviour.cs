using UnityEngine;
using System.Collections;

public class MouseBehaviour : MonoBehaviour {
    public Texture2D target;
    public float targetSize = 25;
	// Use this for initialization
	void Start () {
        //Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Input.mousePosition.x - targetSize / 2, Screen.height - Input.mousePosition.y - targetSize / 2, targetSize, targetSize), target);
    }
}
