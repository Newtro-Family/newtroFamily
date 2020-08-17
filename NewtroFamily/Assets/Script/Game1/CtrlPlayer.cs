using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPlayer : MonoBehaviour
{
    private Collision2D circleTr;

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(circleTr);
    }

    // Update is called once per frame
    void Update()
    {
        OnCollisionEnter2D(circleTr);
    }
    
    /*
    private void OnCollisionEnter(Collision2D collision)
    {
        Debug.Log("하");
        // 제기 Bounce 반사각
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("충돌!!");

            Vector3 reflect = collision.transform.position - circleTr.transform.position;

            float result = 0.0f;

            if (reflect.x > 0) result = 1.0f;
            else if (reflect.x < 0) result = -1.0f;

            collision.rigidbody.AddForce(new Vector3(150.0f * result, 50.0f, 0.0f));

        }
    }
    */

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Ball과 충돌하였음!");
            //GameObject.Find("Canvas").transform.Find("Over").gameObject.SetActive(true);
            //Time.timeScale = 0f;
        }
    }
    
}
