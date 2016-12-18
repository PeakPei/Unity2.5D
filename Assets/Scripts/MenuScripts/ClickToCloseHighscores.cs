using UnityEngine;
using System.Collections;

public class ClickToCloseHighscores : MonoBehaviour {

    public GameObject highscores;

    public void ClickAsync()
    {
        highscores.SetActive(false);
    }
}
