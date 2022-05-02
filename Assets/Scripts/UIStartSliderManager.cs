using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartSliderManager : MonoBehaviour
{
    [SerializeField] private PauseGame pauseGame;
    [SerializeField] private GameObject[] gameObjects;
    private GameObject _nowGameObject;
    private int index;

    private void Start()
    {
        index = 0;
        _nowGameObject = gameObjects[0];
    }

    void Update()
    {
        if (Input.anyKeyDown && pauseGame.resumeGame)
        {
            _nowGameObject.SetActive(false);
            SetNextGameObject();
        }
    }

    private void SetNextGameObject()
    {
        index++;
        if (index < gameObjects.Length)
        {
            _nowGameObject = gameObjects[index];
        } else
        {
            transform.gameObject.SetActive(false);
        }
    }
}
