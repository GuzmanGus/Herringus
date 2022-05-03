using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShubriumWindow : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public void DestroyPanel()
    {
        Debug.Log("Ending panel");
        if(_panel != null)
        {
            _panel.SetActive(false);
        }
    }
}
