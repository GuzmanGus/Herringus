using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartSliderManager : MonoBehaviour
{
    [SerializeField] private PauseGame pauseGame;
    [SerializeField] private GameObject[] gameObjects;

    private PlayerAction _inputActions;
    private GameObject _nowGameObject;
    private int index;

    private void Start()
    {
        index = 0;
        _nowGameObject = gameObjects[0];

        _inputActions = new PlayerAction();
        _inputActions.Enable();
        _inputActions.Player.AnyKey.performed += anyKey => SetNextGameObject();
    }

    private void SetNextGameObject()
    {
        if (pauseGame.resumeGame)
        {
            _nowGameObject.SetActive(false);
            index++;
            if (index < gameObjects.Length)
            {
                _nowGameObject = gameObjects[index];
            }
            else
            {
                _inputActions.Disable();
                transform.gameObject.SetActive(false);
            }
        }
    }
}
