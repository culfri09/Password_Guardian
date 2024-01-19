using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    [SerializeField] private GameObject linearRegression;

    private LinearRegression linearRegressionComponent;

    [SerializeField] private GameObject challenge;

    [SerializeField] private GameObject pass;

    [SerializeField] private GameObject fail;

    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    void OnEnable()
    {
        linearRegressionComponent = linearRegression.GetComponent<LinearRegression>();
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    void OnEndEdit(string userInput)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("User pressed Enter! Input: " + userInput);
            float passwordStrength = linearRegressionComponent.EvaluatePasswordStrength(userInput);
            Debug.Log(passwordStrength);

            if(passwordStrength > 10)
            {
                audioSource.Play();
                challenge.SetActive(false);
                pass.SetActive(true);
            }
            else
            {
                challenge.SetActive(false);
                fail.SetActive(true);
            }
           
        }
    }
}
