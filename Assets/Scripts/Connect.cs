using System.Collections;
using UnityEngine;
using TMPro;

public class Connect : MonoBehaviour
{
<<<<<<< HEAD
    public TMP_Text inputField, inputField1;
    // Start is called before the first frame update
    public async void ConnectServer() {
        inputField1.text = inputField.text;
        StaticClassData.CreatePrograme(inputField.text, "Cli_1");
        string post_result = await StaticClassData.program.PostRequestAsync();
    }
}
=======
    public TMP_Text inputField;

    // Start is called before the first frame update
    public async void ConnectServer()
    {
        StaticClassData.CreatePrograme(inputField.text, "Cli_1");
        string post_result = await StaticClassData.program.PostRequestAsync();
    }
}
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
