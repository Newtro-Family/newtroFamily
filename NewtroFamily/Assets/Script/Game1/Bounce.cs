using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rigidBall;
    public float force = 100000000.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBall = GetComponent<Rigidbody2D>();
    }
    /*
    void Update()
    {
        rigidBall.velocity = new Vector2(0, 0) * force;
    }
    */

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player1")
        {
            Debug.Log("찼다");
            //rigidBall.AddForce());
        }
    }
}
