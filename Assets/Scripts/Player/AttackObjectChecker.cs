using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjectChecker : MonoBehaviour
{
    [SerializeField] private UIHintManager hintManager;

    private PlayerPunkHungerManager _player;
    private Object _object;

    private void Start()
    {
        _player = GetComponent<PlayerPunkHungerManager>();
    }

    void Update()
    {
        /*float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");*/

        if (Input.GetMouseButtonDown(0))
        {
            //if (axisX == 0 && axisZ == 0)
            Debug.Log("Animation Attack");
            Attack();
        }
    }

    private bool CheckCollider(Collider collider)
    {
        Object obj = collider.gameObject.GetComponent<Object>();
        return obj != null;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool value = CheckCollider(other);
        if (value)
        {
            hintManager.SetEnableHint(true);
            _object = other.gameObject.GetComponent<Object>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool value = CheckCollider(other);
        if (value)
        {
            hintManager.SetEnableHint(false);
            _object = null;
        }
    }

    private void Attack()
    {
        if (_object != null)
        {
            _object.HitObject(_player);
        }
    }
}
