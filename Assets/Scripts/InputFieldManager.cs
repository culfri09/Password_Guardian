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

    [SerializeField] private GameObject stopAudio;

    public AudioSource correctAudio;
    public AudioSource incorrectAudio;


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
            float passwordStrength = linearRegressionComponent.EvaluatePasswordStrength(userInput);

            stopAudio.SetActive(false);

            if (passwordStrength > 10)
            {
                if(stopAudio.activeSelf == false)
                {
                    audioSource.Play();
                }
                
                challenge.SetActive(false);
                pass.SetActive(true);
                correctAudio.Play();
            }
            else
            {
                if (stopAudio.activeSelf == false)
                {
                    audioSource.Play();
                }
                challenge.SetActive(false);
                fail.SetActive(true);
                incorrectAudio.Play();
            }
           
        }
    }
}
