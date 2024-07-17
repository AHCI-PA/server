using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VRKeyboardInput : MonoBehaviour
{
    public TMP_Text inputField;
    private TouchScreenKeyboard touchScreenKeyboard;
    // Start is called before the first frame update
    
    public void showVrKeyboard() {
        touchScreenKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Update is called once per frame
    void Update(){
        if(touchScreenKeyboard != null) inputField.text = touchScreenKeyboard.text;
    }
}
