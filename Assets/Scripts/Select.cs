using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] private Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        myButton.Select();
    }
}
