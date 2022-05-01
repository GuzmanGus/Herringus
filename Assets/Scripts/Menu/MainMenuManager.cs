using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void MoveToScene(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
