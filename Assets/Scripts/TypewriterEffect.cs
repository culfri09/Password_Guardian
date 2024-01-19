using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float delay;// Time delay between each character
    public string fullText;     // The full text to be displayed
    private string currentText = "";  // The text currently displayed
    private TextMeshProUGUI textComponent;

    [SerializeField] private GameObject newText;


    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        newText.SetActive(true);
    }
}
