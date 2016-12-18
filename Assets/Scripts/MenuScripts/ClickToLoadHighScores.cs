using UnityEngine;
using System.Collections;

public class ClickToLoadHighScores : MonoBehaviour {

    public GameObject highscore;

    public void ClickAsync()
    {
        highscore.SetActive(true);
    }
}
