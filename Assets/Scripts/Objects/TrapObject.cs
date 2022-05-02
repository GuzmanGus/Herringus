using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour
{
    [SerializeField] private float hunger;
    [SerializeField] private float punk;

    private bool _isEnable;

    private void Start()
    {
        _isEnable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPunkHungerManager player = other.gameObject.GetComponent<PlayerPunkHungerManager>();
        if (player != null && _isEnable)
        {
            player.ChangeHunger(-hunger);
            player.ChangePunk(-punk);
            _isEnable = false;
        }
    }
}
