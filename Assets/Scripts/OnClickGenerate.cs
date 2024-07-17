using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject showMenu, showResult, otherButton;
    public void onClick(){
        if(StaticClassData.generationState){
            showResult.SetActive(true);
        }
        else {
            showMenu.SetActive(true);
        }
        gameObject.SetActive(false);
        otherButton.SetActive(false);
    }
}