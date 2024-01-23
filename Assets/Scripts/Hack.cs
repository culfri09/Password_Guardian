using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hack : MonoBehaviour
{
    public GameObject challenges;
    public AudioSource clickSound;
    public AudioSource typeSound;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;
    public TextMeshProUGUI timerText;
    public GameObject show;

    private float timeRemaining = 30f;

    private bool isAttackInProgress = true;

    private void Start()
    {
        clickSound.Play();
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
                SceneManager.LoadScene("Hack");
            }
        }
    }

    public void Option1()
    {
        challenges.SetActive(false);
        option1.SetActive(true);
        clickSound.Stop();
        typeSound.Play();
    }
    public void Option2()
    {
        challenges.SetActive(false);
        option2.SetActive(true);
        clickSound.Stop();
        typeSound.Play();
    }
    public void Option3()
    {
        challenges.SetActive(false);
        option3.SetActive(true);
        clickSound.Stop();
        typeSound.Play();
    }
    public void Option4()
    {
        challenges.SetActive(false);
        option4.SetActive(true);
        clickSound.Stop();
        typeSound.Play();
    }
}
