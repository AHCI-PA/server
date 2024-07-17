using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    public GameObject ui, button1, button2;
    // Start is called before the first frame update
    public void CloseWindowMethods(){
        ui.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(true);
    }
}
