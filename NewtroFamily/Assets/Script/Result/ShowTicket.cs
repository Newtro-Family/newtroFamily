using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTicket : MonoBehaviour
{
    Button Box;
    public GameObject Ticket;

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
    }
}
