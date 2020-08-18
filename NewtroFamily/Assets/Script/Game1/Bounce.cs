using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rigidBall;
    private float force = 100.0f;
    public float sizeKeyBall = 0.0f;

    // 현재 점수
    public Text txtGoal;
    public int numGoal;

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
        if(col.gameObject.name == "Player1" || col.gameObject.name == "Player2"
            || col.gameObject.name == "Player3" || col.gameObject.name == "Player4")
        {

            // TODO: 난이도 레벨링
            // bounce에서 gravity 조정하는 코드(점점 빨라지게)
            rigidBall.gravityScale *= 1.03f;
            //Debug.Log("중력 크기: " + rigidBall.gravityScale);

            // 제기 크기 랜덤으로 조절 -> x축의 역할
            //RandomBallSize();

            //Debug.Log(col.relativeVelocity + "/" + rigidBall.velocity);
            rigidBall.AddForce(transform.forward * force);

            // 점수
            numGoal++;
        }
    }

    // 제기 크기 랜덤으로 조정하는 함수: 사용자 평가 후 진행
    void RandomBallSize()
    {
        sizeKeyBall = Random.Range(1.0f, 2.0f);
    }

}
