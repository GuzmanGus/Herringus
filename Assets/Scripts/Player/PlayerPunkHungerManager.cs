using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticDaysManager;

public class PlayerPunkHungerManager : MonoBehaviour
{
    [Header("Now value")]
    [SerializeField] private float _hunger = 50f; //start value of hunger
    [SerializeField] private float _punk = 0f;

    [Header("Max states value")]
    [SerializeField] private float maxHunger = 100;
    [SerializeField] private float maxPunk = 100;

    private GameManager gameManager;

    private bool _isLive = true;

    private void Start()
    {
        _punk = StaticDaysManager.punk;
        gameManager = GameManager.Instance;
    }

    public void ChangeHunger(float value)
    {
        _hunger += value;

        if (_hunger < 0)
        {
            _hunger = 0;
            _isLive = false;
            gameManager.Lose();
        } else if (_hunger >= maxHunger)
        {
            _hunger = maxHunger;
            gameManager.FinishDay();
            //buttonEndLevel.SetActive(true);
        }
    }

    public void ChangePunk(float value)
    {
        _punk += value;

        if (_punk < 0)
        {
            _punk = 0;
        }
        else if (_punk > maxPunk)
        {
            _punk = maxPunk;
        }
    }

    public bool CheckIsLive()
    {
        return _isLive;
    }

    public float[] GetStatesPlayer()
    {
        float[] array = new float[2];
        array[0] = _hunger;
        array[1] = _punk;

        return array;
    }

    public float[] GetMaxStatesPlayer()
    {
        float[] array = new float[2];
        array[0] = maxHunger;
        array[1] = maxPunk;

        return array;
    }
}
