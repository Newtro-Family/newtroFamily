using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RealGame2Manager : MonoBehaviour
{
    //UI
    public GameObject loading;

    //변수
    readonly WaitForSeconds term = new WaitForSeconds(1f);


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingScene());
    }

    IEnumerator LoadingScene()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3.0f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        loading.SetActive(false);

        Time.timeScale = 1.0f;
    }

}
