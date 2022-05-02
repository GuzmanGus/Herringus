using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatesManager : MonoBehaviour
{
    [SerializeField] private PlayerPunkHungerManager player;
    [SerializeField] private Image sliderHunger;
    [SerializeField] private Image sliderPunk;

    private float _maxHunger;
    private float _maxPunk;

    private void Start()
    {
        float[] maxStates = player.GetMaxStatesPlayer();

        _maxHunger = maxStates[0];
        _maxPunk = maxStates[1];

    }
    private void FixedUpdate()
    {
        float[] states = player.GetStatesPlayer();

        sliderHunger.fillAmount = states[0] / _maxHunger;
        sliderPunk.fillAmount = states[1] / _maxPunk;
    }
}
