using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool resumeGame = false;
    [SerializeField] private SmallMenuManager smallMenu;

    private PlayerAction _inputAction;

    private void Start()
    {
        //resumeGame = false;
        
        _inputAction = new PlayerAction();
        _inputAction.Enable();
        _inputAction.Player.Pause.performed += pause => PausedGame();
    }

    public void PausedGame()
    {
        if (resumeGame)
        {
            smallMenu.OpenMenu();
            Time.timeScale = 0f;
            resumeGame = false;
        } else
        {
            smallMenu.CloseMenuPanel();
            Time.timeScale = 1f;
            resumeGame = true;
        }
    }
}
