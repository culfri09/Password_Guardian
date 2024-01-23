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
    public AudioSource typeSound;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI jobText;

    private float timeRemaining = 60f;

    private bool isAttackInProgress = true;

    public GameObject email1;
    public GameObject email2;
    public GameObject email3;
    public GameObject email4;
    public GameObject email5;

    public GameObject info;

    private int jobPerformance = 0;


    // Start is called before the first frame update
    void Start()
    {
        clockSound.Play();
    }

    void Update()
    {
        jobText.text =  string.Format("\"{0:000}\"", jobPerformance);
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
                clockSound.Stop();
                info.SetActive(true);
              //  typeSound.Play();
            }
        }
    }

    public void Email1Phishing()
    {
        //Correct
        correctSound.Play();
        email1.SetActive(false);
        jobPerformance += 100;
        email2.SetActive(true);
    }
    public void Email1Safe()
    {
        //Incorrect
        incorrectSound.Play();
        email1.SetActive(false);
        jobPerformance -= 100;
        email2.SetActive(true);
    }

    public void Email2Phishing()
    {
        //Incorrect
        incorrectSound.Play();
        email2.SetActive(false);
        jobPerformance -= 100;
       email3.SetActive(true);
    }
    public void Email2Safe()
    {
        //Correct
        correctSound.Play();
        email2.SetActive(false);
        jobPerformance += 100;
        email3.SetActive(true);
    }

    public void Email3Phishing()
    {
        //Incorrect
        incorrectSound.Play();
        email3.SetActive(false);
        jobPerformance -= 100;
        email4.SetActive(true);
    }
    public void Email3Safe()
    {
        //Correct
        correctSound.Play();
        email3.SetActive(false);
        jobPerformance += 100;
        email4.SetActive(true);
    }

    public void Email4Phishing()
    {
        //Correct
        correctSound.Play();
        email4.SetActive(false);
        jobPerformance += 100;
        email5.SetActive(true);
    }
    public void Email4Safe()
    {
        //Inorrect
        incorrectSound.Play();
        email4.SetActive(false);
        jobPerformance -= 100;
        email5.SetActive(true);
    }

    public void Email5Phishing()
    {
        //Correct
        correctSound.Play();
        email5.SetActive(false);
        jobPerformance += 100;
        clockSound.Stop();
        info.SetActive(true);
        typeSound.Play();
        isAttackInProgress = false;
    }
    public void Email5Safe()
    {
        //Inorrect
        incorrectSound.Play();
        email5.SetActive(false);
        jobPerformance -= 100;
        clockSound.Stop();
        info.SetActive(true);    
        typeSound.Play();
        isAttackInProgress = false;
    }
}
