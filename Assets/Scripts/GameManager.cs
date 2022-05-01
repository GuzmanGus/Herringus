using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    private float _dayDuration = 60.0f; 

    public static GameManager Instance
    {
        get 
        {
            if(_gameManager == null)
            {
                Debug.LogWarning("There is no gamemanager");
            }
            return _gameManager;
        }
    }

    public float DayDuration
    {
        get { return _dayDuration; }
    }

    private void Awake()
    {
        _gameManager = this;
    }

    public void FinishDay()
    {
        Debug.Log("Day is finish");
    }
}
