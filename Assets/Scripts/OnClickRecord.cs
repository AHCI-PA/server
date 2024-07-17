using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class OnClickRecord : MonoBehaviour
{
    // public GameObject interactable_text, button;
    public TMP_Text timer_text, text_button, text_base;
    private long click_time_time_long;
    private DateTime now, click_time, epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    // Update is called once per frame
    void Update()
    {
        //button.onClick.SetListener(SetUI);
        if (timer_text.gameObject.activeSelf)
        {
            now = DateTime.UtcNow;
            long now_long = (long)(now - epoch).TotalSeconds;
            long second_parzial = now_long - click_time_time_long;
            timer_text.text = "00:" + second_parzial.ToString();
        }
    }

    public void SetUI()
    {
        if (!timer_text.gameObject.activeSelf)
        {
            text_base.gameObject.SetActive(false);
            timer_text.gameObject.SetActive(true);
            text_button.text = "STOP";
            text_button.fontSize = 0.04F;
            /*while(timer.SetActive()){
            }*/
            click_time = DateTime.UtcNow;
            click_time_time_long = (long)(click_time - epoch).TotalSeconds;
        }
        else
        {
            text_base.gameObject.SetActive(true);
            timer_text.gameObject.SetActive(false);
            text_button.text = "REC";
            text_button.fontSize = 0.05F;
        }
    }
}