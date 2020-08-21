using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowReward : MonoBehaviour
{
    private Button btnPrize;

    public GameObject reward;

    // Start is called before the first frame update
    void Start()
    {
        btnPrize = GetComponent<Button>();

        btnPrize.onClick.AddListener(ShowPrize);
    }

    void ShowPrize()
    {
        reward.SetActive(true);
        btnPrize.gameObject.SetActive(false);
        Debug.Log("티켓 상자 보기");
    }
}
