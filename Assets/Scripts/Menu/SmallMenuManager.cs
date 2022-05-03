using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMenuManager : MainMenuManager
{
    [SerializeField] private Transform smallMenuPanel;

    private void ResetMenuPanel()
    {
        OpenPanel(smallMenuPanel.parent.gameObject);
        foreach (Transform child in smallMenuPanel.parent)
        {
            if (child != smallMenuPanel)
                ClosePanel(child.gameObject);
            else
                OpenPanel(smallMenuPanel.gameObject);
        }
    }

    public void OpenMenu()
    {
        if (!smallMenuPanel.parent.gameObject.activeSelf)
            ResetMenuPanel();//OpenPanel(smallMenuPanel);
        else
            ClosePanel(smallMenuPanel.parent.gameObject);
    }

    public void CloseMenuPanel()
    {
        ClosePanel(smallMenuPanel.parent.gameObject);
    }
}
