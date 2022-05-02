using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Скрипт, который крепится к UI и позволяет Event использовать метод ...
public class UIAnimationFinishScripter : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void LoseFinishAnimation()
    {
        _gameManager.LoadLose();
    }

    public void SetNewDayFinishAnimation()
    {
        _gameManager.SetNewDay();
    }
}
