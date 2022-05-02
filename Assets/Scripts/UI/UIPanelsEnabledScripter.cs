using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelsEnabledScripter : MonoBehaviour
{
    [SerializeField] private GameObject diePanel; //������ ���������
    [SerializeField] private GameObject winPanelBad; //������ ������ ��������
    [SerializeField] private GameObject winPanelGood; //������ ������� ��������
    [SerializeField] private GameObject finishDayPanel; //������ �������� �� ������ �����
    
    public void DiePanel()
    {
        finishDayPanel.transform.parent.gameObject.SetActive(true);

        diePanel.SetActive(true);
        winPanelBad.SetActive(false);
        winPanelGood.SetActive(false);
        finishDayPanel.SetActive(false);
    }

    public void FinishDay()
    {
        finishDayPanel.transform.parent.gameObject.SetActive(true);

        winPanelGood.SetActive(false);
        diePanel.SetActive(false);
        winPanelBad.SetActive(false);
        finishDayPanel.SetActive(true);
    }

    public void WinPanel(bool isGood)
    {
        finishDayPanel.transform.parent.gameObject.SetActive(true);

        if (isGood)
        {
            winPanelGood.SetActive(true);
            diePanel.SetActive(false);
            winPanelBad.SetActive(false);
            finishDayPanel.SetActive(false);
        }
        else
        {
            winPanelGood.SetActive(false);
            diePanel.SetActive(false);
            winPanelBad.SetActive(true);
            finishDayPanel.SetActive(false);
        }
    }
}
