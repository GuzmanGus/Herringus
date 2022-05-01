using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunkHungerManager : MonoBehaviour
{
    [SerializeField] private float _hunger;
    [SerializeField] private float _punk;
    private bool _isLive = true;

    public void ChangeHunger(float value)
    {
        _hunger += value;

        if (_hunger < 0)
        {
            _hunger = 0;
            _isLive = false;
        }
    }

    public void ChangePunk(float value)
    {
        _punk += value;

        if (_punk < 0)
        {
            _punk = 0;
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
}
