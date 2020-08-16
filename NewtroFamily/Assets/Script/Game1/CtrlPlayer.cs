using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPlayer : MonoBehaviour
{
    private Transform sphereTr;

    // Start is called before the first frame update
    void Start()
    {
        sphereTr = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 제기 Bounce 반사각
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 reflect = collision.transform.position - sphereTr.position;

            float result = 0.0f;

            if (reflect.x > 0) result = 1.0f;
            else if (reflect.x < 0) result = -1.0f;

            collision.rigidbody.AddForce(new Vector3(150.0f * result, 50.0f, 0.0f));
        }
    }
}
