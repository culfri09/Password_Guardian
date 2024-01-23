using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Emails : MonoBehaviour
{

    public AudioSource clockSound;
    public AudioSource correctSound;
    public AudioSource incorrectSound;

    public TextMeshProUGUI timerText;
    

    private float timeRemaining = 60f;

    private bool isAttackInProgress = true;

    // Start is called before the first frame update
    void Start()
    {
        clockSound.Play();
    }

    void Update()
    {
        if (isAttackInProgress)
        {
            if (timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;

                // Convert the timeRemaining to minutes and seconds
                int minutes = Mathf.FloorToInt(timeRemaining / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                timerText.text = string.Format("\"{0:00}:{1:00}\"", minutes, seconds);
            }
            else
            {
                timerText.text = "\"00:00\"";
                SceneManager.LoadScene("AfterChallenge4");
            }
        }
    }

    public void Email1Phishing()
    {
        //Correct
    }
    public void Email2Safe()
    {
        //Incorrect
    }
}
