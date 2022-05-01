using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PauseGame pauseGame;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 _moveInput;

    private PlayerAction _playerActions;
    private Rigidbody _rigidBody;


    void Awake()
    {
        _playerActions = new PlayerAction();
        _rigidBody = transform.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        if (pauseGame.resumeGame)
        {
            _moveInput = _playerActions.Player.Movement.ReadValue<Vector3>();
            _moveInput = new Vector3(_moveInput.x, _moveInput.z, _moveInput.y);
            _moveInput.y = 0f;
            _rigidBody.velocity = _moveInput * speed * Time.deltaTime;
        }
        //transform.position +=  _moveInput * speed * Time.deltaTime;
    }
}
