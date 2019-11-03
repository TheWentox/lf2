using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Slider slider;
    public AudioSource audioSource;

    void Start()
    {
        slider.value = 0.2f;
    }

    void Update()
    {
        audioSource.volume = slider.value;
    }
}
