using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class FontFormatter : MonoBehaviour
{
    public TMP_Text text;
    private bool overSpace;
    // Start is called before the first frame update
<<<<<<< HEAD
    void Start() {
        //text.enableAutoSizing = true;
        
        
    }

    // Update is called once per frame
    void Update() {
        //var textbounds = text.bounds;
       //var sizeDelta = text.rectTransform.anchoredPosition;
=======
    void Start()
    {
        //text.enableAutoSizing = true;


    }

    // Update is called once per frame
    void Update()
    {
        //var textbounds = text.bounds;
        //var sizeDelta = text.rectTransform.anchoredPosition;
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
        /*if(textbounds.size.x >= 0.55) {
            text.fontSize -= 0.001F;
            Debug.Log("Currently anchored position for size delta: " + sizeDelta.y);
            //sizeDelta.y -= 0.01F;
            Debug.Log("Currently anchored position for transform: " + text.rectTransform.anchoredPosition.y);
        }
        else if(Math.Abs(textbounds.size.y-0.55) < 0.1)
            text.fontSize += 0.001F;*/
<<<<<<< HEAD
    
=======

>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
    }
}