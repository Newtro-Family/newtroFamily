using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTicket : MonoBehaviour
{
    Button Box;
    public GameObject Ticket;
    public GameObject txtScoreGroup;    // 점수판에 점수들
    public Text txtGuide;   // 안내문

    // Start is called before the first frame update
    void Start()
    {
        Box = GetComponent<Button>();

        Box.onClick.AddListener(ShowMyTicket);
    }

    void ShowMyTicket()
    {
        Ticket.SetActive(true);
        Debug.Log(Box.name);

        //txtScoreGroup.SetActive(false);
        //txtGuide.gameObject.SetActive(false);
    }
}
