using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject scoreObject;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = scoreObject.GetComponent<ScoreManager>();
    }

    private void Update()
    {
        scoreText.text = "\"" + scoreManager.score.ToString() + "\"";
    }
}
