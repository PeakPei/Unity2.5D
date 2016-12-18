using UnityEngine;
using System.Collections;

public class ClickToCloseAbout : MonoBehaviour {

    public GameObject aboutScreen;

    public void ClickAsync()
    {
        aboutScreen.SetActive(false);
    }
}
