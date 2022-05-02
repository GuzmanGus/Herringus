using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunkHungerManager : MonoBehaviour
{
    [Header("Now value")]
    [SerializeField] private float _hunger;
    [SerializeField] private float _punk;

    [Header("Max states value")]
    [SerializeField] private float maxHunger;
    [SerializeField] private float maxPunk;

    private bool _isLive = true;

    public void ChangeHunger(float value)
    {
        _hunger += value;

        if (_hunger < 0)
        {
            _hunger = 0;
            _isLive = false;
        } else if (_hunger > maxHunger)
        {
            _hunger = maxHunger;
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
