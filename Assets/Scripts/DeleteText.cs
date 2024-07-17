using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeleteText : MonoBehaviour
{
    public TMP_Text text;

    public void ClearTMP(){
        text.text = "";
    }

}
