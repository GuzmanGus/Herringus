using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHintManager : MonoBehaviour
{
    [SerializeField] private GameObject panelHint;
    void Update()
    {
        
    }

    public void SetEnableHint(bool value)
    {
        panelHint.SetActive(value);
    }
}
