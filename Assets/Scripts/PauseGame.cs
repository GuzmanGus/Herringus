using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool resumeGame = false;

    private PlayerAction _inputAction;

    private void Start()
    {
        resumeGame = false;
        
        _inputAction = new PlayerAction();
        _inputAction.Player.Pause.performed += pause => PausedGame();
    }

    public void PausedGame()
    {
        Debug.Log("Pause");
        /*Time.timeScale = 0f;
        resumeGame = false;*/
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        resumeGame = true;
    }
}
