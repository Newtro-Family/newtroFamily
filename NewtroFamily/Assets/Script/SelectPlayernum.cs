using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayernum : MonoBehaviour
{
    //변수

    //UI
    public GameObject player2,player3,player4;

    //Resource
    public Sprite younghee,chulsoo;
    public Sprite plus;
    // Start is called before the first frame update
 
    //플레이어 수 2명
    public void Plusplayer2()
    {
        player2.GetComponent<Image>().sprite = Resources.Load("younghee", typeof(Sprite)) as Sprite;
        player3.SetActive(true);
    }

    //플레이어 수 3명
    public void Plusplayer3()
    {
        player3.GetComponent<Image>().sprite = Resources.Load("chulsoo", typeof(Sprite)) as Sprite;
        player4.SetActive(true);
    }

    //플레이어 수 4명
    public void Plusplayer4()
    {
        GetComponent<Button>().interactable = false;
    }
}
