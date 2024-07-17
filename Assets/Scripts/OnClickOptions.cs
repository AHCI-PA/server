using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnClickOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject showMenu, otherButton;

    public void onClick(){
        otherButton.SetActive(false);
        gameObject.SetActive(false);
        showMenu.SetActive(true);
    }
}
