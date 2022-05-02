using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatesManager : MonoBehaviour
{
    [SerializeField] private PlayerPunkHungerManager player;
    [SerializeField] private Slider sliderHunger;
    [SerializeField] private Slider sliderPunk;

    private void Start()
    {
        float[] maxStates = player.GetMaxStatesPlayer();

        sliderHunger.maxValue = maxStates[0];
        sliderPunk.maxValue = maxStates[1];
    }

    void FixedUpdate()
    {
        float[] states = player.GetStatesPlayer();

        sliderHunger.value = states[0];
        sliderPunk.value = states[1];
    }
}
