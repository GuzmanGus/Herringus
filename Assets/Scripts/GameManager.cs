using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UITimer _timer;
    [SerializeField] private List<Light> _daysLight = new List<Light>();

    private static GameManager _gameManager;
    private static int _currentDayNum;
    private float _dayDuration = 10.0f;

    private List<string> _days = new List<string>();
    private string _currentDay;
    //Dictionary<string, Light> _daysLight = new Dictionary<string, Light>();

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
    public static int CurrentDayNum
    {
        get { return _currentDayNum; }
    }

    public float DayDuration
    {
        get { return _dayDuration; }
    }


    private void Awake()
    {
        _gameManager = this;

        _days.Add("Education day");
        _days.Add("Day 1");
        _days.Add("Day 2");
        _days.Add("Day 3");

        _currentDayNum = 0;
    }

    public void FinishDay()
    {
        Debug.Log("Day is finish");
        string day = SetNewDay(); // calling by button "Start new Day"
    }

    public string SetNewDay()
    {
        _currentDayNum++;

        _timer.Inizialize();

        //SceneManager.LoadScene(_currentDayNum);
        return _days[_currentDayNum];
    }
}
