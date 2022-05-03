using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIHungerChangerWithTime : MonoBehaviour
{
    [SerializeField] private PlayerPunkHungerManager player;
    [SerializeField] private float _timeChange = 10;
    [SerializeField] private float _hungerChanger = 3;
    [SerializeField] private float _timeRemains;

    private float _nowTime;
    

    private void Start()
    {
        _nowTime = Time.time;
        _timeRemains = (float)Math.Round(_nowTime % _timeChange, 2);

        _nowTime += 0.01f;
    }

    private void FixedUpdate()
    {
        _nowTime = Time.time;
        //Debug.Log(_nowTime % _timeChange);

        if ((float)Math.Round(_nowTime % _timeChange) == _timeRemains)
        {
            player.ChangeHunger(-_hungerChanger);
            Debug.Log("true change hunger");
        }
    }
}
