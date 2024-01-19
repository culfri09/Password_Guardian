using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    private string userPassword;

    void OnEnable()
    {
        inputField.Select();
        inputField.ActivateInputField();
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    void OnEndEdit(string userInput)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("User pressed Enter! Input: " + userInput);
            userPassword = userInput;
        }
    }
}
