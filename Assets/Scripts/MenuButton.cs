using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
    private AsyncOperation async;
    public GameObject player;
    public GameObject GameManager;
    public GameObject Lightning;
    public GameObject canvas;
    public GameObject sky;
    public GameObject mainCamera;
    private GameObject bMusic;

    public void ClickAsync(int level)
    {
        Destroy(player);
        Destroy(GameManager);
        Destroy(Lightning);
        bMusic = GameObject.Find("BackgroundMusic");
        Destroy(bMusic);
        Destroy(mainCamera);
        Destroy(sky);
        StartCoroutine(LoadLevel(level));
        Destroy(canvas);
        

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
