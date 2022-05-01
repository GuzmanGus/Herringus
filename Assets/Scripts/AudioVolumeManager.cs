using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource audioSource;

    void FixedUpdate()
    {
        audioSource.volume = volumeSlider.value;
    }
}
