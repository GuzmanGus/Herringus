using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    private const string _timeTextPrefix = "Time: ";

    private float _currentTime;
    private float _startTime;

    private bool _gameOver;
    private void Start()
    {
        Inizialize();
    }

    public void Inizialize()
    {
        _startTime = GameManager.Instance.DayDuration;
        _timeText.text = _timeTextPrefix + _startTime.ToString();

        _gameOver = false;

        _currentTime = _startTime;
    }

    void Update()
    {
        if(!_gameOver)
        {
            if(_currentTime <= 0.0f)
            {
                _gameOver = true;
                _timeText.text = _timeTextPrefix + "00:00";
            }
            else
            {
                _currentTime -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(_currentTime / 60.0f);
                int seconds = Mathf.FloorToInt(_currentTime % 60.0f);

                _timeText.text = _timeTextPrefix + minutes.ToString() + ":" + seconds.ToString();
            }
        }
        else 
        {
            GameManager.Instance.FinishDay();
        }
    }
}
