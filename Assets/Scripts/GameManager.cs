using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    private float _dayDuration = 60.0f;

    private List<string> _days = new List<string>();
    private List<Light> _daysLight = new List<Light>();
    //Dictionary<string, Light> _daysLight = new Dictionary<string, Light>();
    private string _currentDay;

    private int _dayNum;
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

    public string CurrentDay
    {
        get { return _currentDay; }
    }

    private void Awake()
    {
        _gameManager = this;

        _days.Add("Day 1");
        _days.Add("Day 2");
        _days.Add("Day 3");

        _dayNum = 1;

        _currentDay = _days[_dayNum];
    }

    public void FinishDay()
    {
        Debug.Log("Day is finish");
        _dayNum++;
    }

    public void SetNewDay()
    {
        _currentDay = _days[_dayNum];
    }
}
