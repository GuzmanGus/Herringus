using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHungerChangerWithTime : MonoBehaviour
{
    [SerializeField] private PlayerPunkHungerManager player;
    [SerializeField] private float _timeChange = 10;
    [SerializeField] private float _hungerChanger = 5;

    private float _nowTime;
    private float _timeRemains;

    private void Start()
    {
        _nowTime = Time.time;
        _timeRemains = _nowTime % _timeChange;

        _nowTime += 0.01f;
    }

    private void FixedUpdate()
    {
        _nowTime = Time.time;

        if (_nowTime % _timeChange == _timeRemains)
        {
            player.ChangeHunger(-_hungerChanger);
        }
    }
}
