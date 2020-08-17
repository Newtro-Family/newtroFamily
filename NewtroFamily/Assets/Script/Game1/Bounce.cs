using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rigidBall;
    public float force = 100.0f;

    // 현재 점수
    public Text txtGoal;
    private int numGoal;

    // Start is called before the first frame update
    void Start()
    {
        rigidBall = GetComponent<Rigidbody2D>();
        // 점수 초기화
        txtGoal.text = "0";
        numGoal = 0;
    }
    
    void Update()
    {
        //rigidBall.velocity = new Vector2(0, 0) * force;
        txtGoal.text = numGoal.ToString();
    }
    

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player1")
        {
            Debug.Log(col.relativeVelocity + "/" + rigidBall.velocity);
            rigidBall.AddForce(transform.forward * force);

            // 점수
            numGoal++;
        }
    }
}
