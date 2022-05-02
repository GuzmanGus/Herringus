using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatesManager : MonoBehaviour
{
    [SerializeField] private PlayerPunkHungerManager player;
    [SerializeField] private Slider sliderHunger;
    [SerializeField] private Slider sliderPunk;

    void ChangeSliders()
    {
        float[] states = player.GetStatesPlayer();

        sliderHunger.value = states[0];
        sliderPunk.value = states[1];
    }
}
