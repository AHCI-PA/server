using System.Collections;
using UnityEngine;
using TMPro;

public class Connect : MonoBehaviour
{
    public TMP_Text inputField, inputField1;
    // Start is called before the first frame update
    public async void ConnectServer() {
        inputField1.text = inputField.text;
        StaticClassData.CreatePrograme(inputField.text, "Cli_1");
        string post_result = await StaticClassData.program.PostRequestAsync();
    }
}
