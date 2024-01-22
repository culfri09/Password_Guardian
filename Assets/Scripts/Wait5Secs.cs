using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait5Secs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait3Secs(3f));
    }
    
    IEnumerator Wait3Secs(float secondsToShow)
    {
        yield return new WaitForSeconds(secondsToShow);
        SceneManager.LoadScene("Emails");

    }
}

