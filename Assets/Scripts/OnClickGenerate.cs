using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject showMenu, showResult, otherButton;
<<<<<<< HEAD
    public void onClick(){
        if(StaticClassData.generationState){
            showResult.SetActive(true);
        }
        else {
=======

    public void onClick()
    {
        if (StaticClassData.generationState)
        {
            showResult.SetActive(true);
        }
        else
        {
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
            showMenu.SetActive(true);
        }
        gameObject.SetActive(false);
        otherButton.SetActive(false);
    }
}