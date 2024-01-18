using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{
    [SerializeField]  private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource.Stop();
    }
}
