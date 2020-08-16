using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPlayer : MonoBehaviour
{
    private Transform circleTr;

    // Start is called before the first frame update
    void Start()
    {
        circleTr = GetComponent<Transform>();
        Debug.Log(circleTr);
    }

    // Update is called once per frame
    void Update()
    {
        OnCollisionEnter(circleTr);
    }

    private void OnCollisionEnter(Transform circleTr)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("하");
        // 제기 Bounce 반사각
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("충돌!!");

            Vector3 reflect = collision.transform.position - circleTr.position;

            float result = 0.0f;

            if (reflect.x > 0) result = 1.0f;
            else if (reflect.x < 0) result = -1.0f;

            collision.rigidbody.AddForce(new Vector3(150.0f * result, 50.0f, 0.0f));

        }
    }
}
