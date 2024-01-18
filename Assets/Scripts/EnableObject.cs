using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void OnEnable()
    {
        targetObject.SetActive(true);
    }
}
