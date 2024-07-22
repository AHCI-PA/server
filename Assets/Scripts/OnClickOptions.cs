using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnClickOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject showMenu, otherButton;

<<<<<<< HEAD
    public void onClick(){
=======
    public void onClick()
    {
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
        otherButton.SetActive(false);
        gameObject.SetActive(false);
        showMenu.SetActive(true);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
