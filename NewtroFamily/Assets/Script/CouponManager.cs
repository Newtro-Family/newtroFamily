using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouponManager : MonoBehaviour
{
    
    public GameObject couponbox, popup;

    public void ClickCouponbox()
    {
        couponbox.SetActive(true);
    }
    public void ClickCancel()
    {
        couponbox.SetActive(false);
        popup.SetActive(false);
    }

    public void Clickplayer1()
    {
        popup.SetActive(true);
    }
}
