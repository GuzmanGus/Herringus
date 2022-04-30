using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearMovement : MonoBehaviour
{
    [SerializeField] private float _bearSpeed = 2.0f;
    [SerializeField] private float _bearRotationSpeed = 180.0f;

    private CharacterController _bearCharacterController;

    private Vector3 _bearDirection;
    private Quaternion _bearRotation;
    private float _directionX;
    private float _directionZ;

    private void Awake()
    {
        _bearCharacterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        _directionZ = Input.GetAxisRaw("Vertical");

        _bearDirection = transform.TransformDirection(_directionX, 0.0f, _directionZ);
        _bearRotation = Quaternion.LookRotation(_bearDirection, Vector3.up);

        if (_bearDirection.magnitude > 0.1f)
        {
            _bearCharacterController.Move(_bearDirection * _bearSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _bearRotation, _bearRotationSpeed * Time.deltaTime);
        }
    }
}
