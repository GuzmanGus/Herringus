using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static StaticDaysManager;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UITimer _timer;

    private static GameManager _gameManager;
    private static int _currentDayNum;

    //[SerializeField] private float _dayDuration = 300.0f;
    private float _dayDuration = 300.0f;
    [SerializeField] private PlayerPunkHungerManager player;
    [SerializeField] private UIPanelsEnabledScripter uiPanel;
    [SerializeField] private float requiredPunk;

    private List<int> _days = new List<int>();
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

        //_days.Add("Education day");
        _days.Add(1);
        _days.Add(2);
        _days.Add(3);

        _currentDayNum = StaticDaysManager.nowDay;
    }

    public void FinishDay()
    {
        Debug.Log("Day is finish");
        uiPanel.FinishDay();  //calling from PunkHunger, when hunger is full, BAG! Check if load next scene - solition see finishdaybutton
        //int day = SetNewDay(); // calling by button "Start new Day"
    }

    public void Lose()
    {
        uiPanel.DiePanel();
    }

    public void LoadLose()
    {
        StaticDaysManager.nowDay = 0;  //check to load scene index 1 or index 0 (if we want to go to the main menu)
        StaticDaysManager.punk = 0;

        SceneManager.LoadScene(_days[0]);  //check if load level1 (not main menu)
    }

    public int SetNewDay()
    {
        _currentDayNum++;
        StaticDaysManager.punk += player.GetStatesPlayer()[1];
        float _nowPunk = StaticDaysManager.punk;

        if (_currentDayNum < _days.Count)
        {
            _timer.Inizialize();
            StaticDaysManager.nowDay = _currentDayNum;

            SceneManager.LoadScene(_days[_currentDayNum]);
            return _days[_currentDayNum];
        }
        else
        {
            if (_nowPunk < requiredPunk)
            {
                uiPanel.WinPanel(false);
            } else
            {
                uiPanel.WinPanel(true);
            }
            return _days[_days.Count - 1];
        }
    }
    public void FinishDayButton() //correct function for button
    {
        int i = SetNewDay();
    }
}
