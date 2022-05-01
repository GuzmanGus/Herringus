using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool resumeGame = false;

    private void Start()
    {
        resumeGame = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            resumeGame = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        resumeGame = true;
    }
}
