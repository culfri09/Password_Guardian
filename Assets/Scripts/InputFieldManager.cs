using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    [SerializeField] private GameObject linearRegression;

    private LinearRegression linearRegressionComponent;

    [SerializeField] private GameObject scoreManager;

    private ScoreManager scoreManagerComponent;

    [SerializeField] private GameObject challenge;

    [SerializeField] private GameObject pass;

    [SerializeField] private GameObject fail;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject stopAudio;



    private void Start()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    void OnEnable()
    {
        linearRegressionComponent = linearRegression.GetComponent<LinearRegression>();
        scoreManagerComponent = scoreManager.GetComponent<ScoreManager>();
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
                scoreManagerComponent.score += passwordStrength;
            }
            else
            {
                if (stopAudio.activeSelf == false)
                {
                    audioSource.Play();
                }
                challenge.SetActive(false);
                fail.SetActive(true);
                scoreManagerComponent.score += passwordStrength;
            }
           
        }
    }
}
