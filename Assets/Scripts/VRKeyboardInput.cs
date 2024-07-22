<<<<<<< HEAD
=======

>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using TMPro;

public class VRKeyboardInput : MonoBehaviour
{
    public TMP_Text inputField;
    private TouchScreenKeyboard touchScreenKeyboard;
    // Start is called before the first frame update
    
    public void showVrKeyboard() {
=======

public class VRKeyboardInput : MonoBehaviour
{
    private InputField inputField;
    private TouchScreenKeyboard touchScreenKeyboard;
    // Start is called before the first frame update

    public void showVrKeyboard()
    {
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
        touchScreenKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Update is called once per frame
<<<<<<< HEAD
    void Update(){
        if(touchScreenKeyboard != null) inputField.text = touchScreenKeyboard.text;
    }
}
=======
    void Update()
    {
        if (touchScreenKeyboard != null)
            inputField.text = touchScreenKeyboard.text;
    }
}
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
