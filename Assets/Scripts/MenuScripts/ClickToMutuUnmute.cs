using UnityEngine;
using System.Collections;

public class ClickToMutuUnmute : MonoBehaviour {
    public float volume = 0.3F;
    private bool muted = false;
    
    public AudioSource backgroundMusic;

    public void OnClick()
    {
        if (!muted)
        {
            backgroundMusic.volume = 0;
            muted = true;
        }
        else
        {
            backgroundMusic.volume = volume;
            muted = false;
        }

    }
}
