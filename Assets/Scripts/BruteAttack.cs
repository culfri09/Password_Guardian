using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BruteAttack : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;

    [SerializeField] private AudioSource correctSound;

    [SerializeField] private AudioSource incorrectSound;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI salaryText;
    private float timeRemaining = 60f;
    private float salary = 600f;
    [SerializeField] private InputField passwordIF;

    private string aliciaPassword = "alicia123";

    private bool isAttackInProgress = true;

    [SerializeField] private GameObject failObject;

    private TextMeshProUGUI failText;

    [SerializeField] private GameObject passObject;


    public GameObject tipObject;


    private TextMeshProUGUI tipText;

    public TextMeshProUGUI characterCountText;

    string[] tips = {
    "\"\"\"Numbers play a role in Alicia's password\"\"\"",
    "\"\"\"Think about commonly used and easy-to-remember numbers\"\"\"",
    "\"\"\"Consider the length of Alicia's full name and how it might contribute to her password.\"\"\"",
    "\"\"\"Experiment with alphabetical characters from Alicia's name with numeric sequences.\"\"\"",
    "\"\"\"Remember, Alicia's password should be easy to recall. Keep it simple!\"\"\"",
    "\"\"\"Alicia's password is intentionally easy to recall.\"\"\"",
    "\"\"\"Keep in mind that the password consists of lowercase letters only.\"\"\"",
    "\"\"\"It's a combination of Alicia's name and simple numeric characters.\"\"\"",
    "\"\"\"The password follows the pattern: alicia + easy-to-remember numbers.\"\"\"",
    "\"\"\"Don't overthink it! The simplicity of the password is key.\"\"\""
    };



    private void Start()
    {
        passwordIF.Select();
        passwordIF.ActivateInputField();
        clickSound.Play();
        passwordIF.onEndEdit.AddListener(OnEndEdit);
        failText = failObject.GetComponent<TextMeshProUGUI>();
        tipText = tipObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        characterCountText.text = "[" + passwordIF.text.Length + "]";
        if (isAttackInProgress)
        {
            if (timeRemaining > 0)
        {

            timeRemaining -= Time.deltaTime;
            salary -= Time.deltaTime * 10;

            // Convert the timeRemaining to minutes and seconds
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerText.text = string.Format("\"{0:00}:{1:00}\"", minutes, seconds);
            salaryText.text = string.Format("\"{0:000}K\"", salary);
        }
        else
        {
            timerText.text = "\"00:00\"";
                StartCoroutine(Wait3Secs(3f));
                EndAttack();
        }
        }
    }
    private void OnEndEdit(string userInput)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {      
            if (passwordIF.text == aliciaPassword)
            {
                AccessGranted();
            }
            else
            {
                passwordIF.Select();
                passwordIF.ActivateInputField();
                AccessDenied();
            }
        }
            }
    private void AccessGranted()
    {     
        correctSound.Play();
        passObject.SetActive(true);

        StartCoroutine(Wait3Secs(4.5f));
        EndAttack();
    }
    IEnumerator Wait3Secs(float secondsToShow)
    {
        yield return new WaitForSeconds(secondsToShow);
        SceneManager.LoadScene("AfterChallenge2");

    }

    private void AccessDenied()
    {
        StartCoroutine(ShowObjectForSeconds(3f));
        StartCoroutine(ShowTip());
        
        incorrectSound.Play();
    }

    IEnumerator ShowTip()
    {
        string currentText = "";
        string randomTip = tips[Random.Range(0, tips.Length)];
        for (int i = 0; i <= randomTip.ToString().Length; i++)
        {
            currentText = randomTip.Substring(0, i);
            tipText.text = currentText;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ShowText()
    {
        string fullText = "Access denied";
        string currentText = "";
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            failText.text = currentText;
            yield return new WaitForSeconds(0.02f);
        }

    }


    IEnumerator ShowObjectForSeconds(float secondsToShow)
    {
        failObject.SetActive(true);
        StartCoroutine(ShowText());

        yield return new WaitForSeconds(secondsToShow);
        StartCoroutine(HideText());
          
    }
    IEnumerator HideText()
    {
        string fullText = "Acces denied";
        string currentText = "";

        for (int i = fullText.Length; i >= 0; i--)
        {
            currentText = fullText.Substring(0, i);
            failText.text = currentText;
            yield return new WaitForSeconds(0.04f);
        }
        failObject.SetActive(false);
    }


    private void EndAttack()
    {
        isAttackInProgress = false;
        clickSound.Stop();     
    }
}
