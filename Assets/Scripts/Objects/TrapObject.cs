using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour
{
    [SerializeField] private AnimationObject animationObject;
    [SerializeField] private float hunger;
    [SerializeField] private float punk;

    private bool _isEnable;

    private void Start()
    {
        _isEnable = true;
        animationObject = GetComponent<AnimationObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPunkHungerManager player = other.gameObject.GetComponent<PlayerPunkHungerManager>();
        if (player != null && _isEnable)
        {
            _isEnable = false;
            Debug.Log("Enabled "+ " = " + _isEnable);
            player.ChangeHunger(-hunger);
            player.ChangePunk(-punk);
            animationObject.AnimHit();
            other.GetComponent<PlayerMovement>().GetTrap();
        }
    }
}
