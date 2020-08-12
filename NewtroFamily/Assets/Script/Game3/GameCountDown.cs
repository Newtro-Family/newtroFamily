using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCountDown : MonoBehaviour
{
    public GameObject countDown1;

    //변수

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 6.0f;
        while(Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDown1.gameObject.SetActive(false);

        Time.timeScale = 1.0f;
    }
}
