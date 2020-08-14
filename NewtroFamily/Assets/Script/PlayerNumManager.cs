using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumManager : MonoBehaviour
{
    public int player_num;
    public GameObject playernum;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(playernum);
    }

    // Update is called once per frame
    public void PlusPlayerNum()
    {
        player_num ++;
    }
    public void MinusPlayerNum()
    {
        player_num --;
    }

}
