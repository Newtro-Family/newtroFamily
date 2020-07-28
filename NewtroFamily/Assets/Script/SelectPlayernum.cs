using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayernum : MonoBehaviour
{
    //변수

    //UI
    public GameObject player2,player3,player4,cancle2,cancle3,cancle4;

    //Resource
    public Sprite dahye, younghee, chulsoo;
    public Sprite plus;
    // Start is called before the first frame update
 
    //플레이어 수 2명
    public void Plusplayer2()
    {
        player2.GetComponent<Image>().sprite = Resources.Load("dahye", typeof(Sprite)) as Sprite;
        cancle2.SetActive(true);
        player3.SetActive(true);

    }

    //플레이어 수 3명
    public void Plusplayer3()
    {
        player3.GetComponent<Image>().sprite = Resources.Load("younghee", typeof(Sprite)) as Sprite;
        cancle3.SetActive(true);
        player4.SetActive(true);
    }

    //플레이어 수 4명
    public void Plusplayer4()
    {
        player4.GetComponent<Image>().sprite = Resources.Load("chulsoo", typeof(Sprite)) as Sprite;
        cancle4.SetActive(true);
    }
    
    //캐릭터 2 취소 
    public void Cancle2()
    {
        player2.GetComponent<Image>().sprite = Resources.Load("plus", typeof(Sprite)) as Sprite;
        cancle2.SetActive(false);
        player3.SetActive(false);
    }
    public void Cancle3()
    {
        player3.GetComponent<Image>().sprite = Resources.Load("plus", typeof(Sprite)) as Sprite;
        cancle3.SetActive(false);
        player4.SetActive(false);
    }
    public void Cancle4()
    {
        player4.GetComponent<Image>().sprite = Resources.Load("plus", typeof(Sprite)) as Sprite;
        cancle4.SetActive(false);
    }
}
