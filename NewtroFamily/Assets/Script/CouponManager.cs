using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouponManager : MonoBehaviour
{
    
    public GameObject popup1,popup2,popup3,popup4;

    public void Clickplayer1()
    {
        popup1.SetActive(true);
    }

    public void Clickplayer2()
    {
        popup2.SetActive(true);
    }

    public void Clickplayer3()
    {
        popup3.SetActive(true);
    }

    public void Clickplayer4()
    {
        popup4.SetActive(true);
    }

    //팝업창 닫기
    public void Cancle1()
    {
        popup1.SetActive(false);
    }
    public void Cancle2()
    {
        popup2.SetActive(false);
    }
    public void Cancle3()
    {
        popup3.SetActive(false);
    }
    public void Cancle4()
    {
        popup4.SetActive(false);
    }
}
