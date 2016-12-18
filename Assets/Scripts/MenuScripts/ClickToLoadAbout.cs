using UnityEngine;
using System.Collections;

public class ClickToLoadAbout : MonoBehaviour {
    public GameObject aboutScreen;

    public void ClickAsync()
    {
        aboutScreen.SetActive(true);
    }
}
