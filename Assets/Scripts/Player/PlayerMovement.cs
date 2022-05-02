using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PauseGame pauseGame;
    [SerializeField] private float _speedMovement = 5f;
    [SerializeField] private float _speedRotation = 180f;
    [SerializeField] private Vector3 _moveInput;
    [SerializeField] private Quaternion _playerRotation;

    private PlayerAction _playerActions; //find new Input Action

    private CharacterController _playerCharacterController;

    private Animator _playerAnimator;

    private Ray _ray;

    private bool _isMoving = true;

    private PlayerPunkHungerManager _player;
    private AudioScripter _audioScripter;

    void Awake()
    {
        _playerActions = new PlayerAction();

        _playerCharacterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<Animator>();

        _player = GetComponent<PlayerPunkHungerManager>();
        _audioScripter = GetComponent<AudioScripter>();

        _playerActions.Player.Kick.performed += context => Kick();
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
            _moveInput = transform.TransformDirection(_moveInput.x, 0.0f, _moveInput.y);

            _playerRotation = Quaternion.LookRotation(_moveInput, Vector3.up);

            Debug.DrawLine(this.transform.position + (_playerCharacterController.center / 2), this.transform.position + (_playerCharacterController.center / 2) + this.transform.forward * 1.2f, Color.yellow);

            if (_moveInput.magnitude > 0.1f && _isMoving) // for version with avatar mask
                                                          //if (_moveInput.magnitude > 0.1f) //for avatar mask
            {
                _playerCharacterController.SimpleMove(_moveInput * _speedMovement * Time.fixedDeltaTime);

                TurnOnMoveAnimation();

                transform.rotation = Quaternion.RotateTowards(transform.rotation, _playerRotation, _speedRotation * Time.fixedDeltaTime);
            }
            else
            {
                TurnOffMoveAnimation();
            }
        }
    }
    private void Kick()
    {
        if (pauseGame.resumeGame)
        {
            _isMoving = false; // for version with no avatar mask
                               //_playerAnimator.SetLayerWeight(_playerAnimator.GetLayerIndex("Kick Layer"), 1); // for version with avatar mask
            _playerAnimator.SetTrigger("Kick");

            Vector3 startPosition = this.transform.position + (_playerCharacterController.center / 2);
            Vector3 targetPosition = startPosition + this.transform.forward * 1.2f;

            RaycastHit hit;
            if (Physics.Linecast(startPosition, targetPosition, out hit))
            {
                if (hit.transform.GetComponent<Object>() != null)
                {

                    hit.transform.GetComponent<Object>().AudioHitObject(_audioScripter); //take the score of eating and punk from object
                    hit.transform.GetComponent<Object>().HitObject(_player); //take the score of eating and punk from object
                }
            }
            else
            {
                Debug.Log("There is not active object");
            }
        }
    }
    private void AllowMove() //calling from end of kicking animation 
    {
        _isMoving = true; // for version with no avatar mask
        //_playerAnimator.SetLayerWeight(_playerAnimator.GetLayerIndex("Kick Layer"), 0); // for version with avatar mask
        Debug.Log("isMoving" + _isMoving);
    }
    private void TurnOnMoveAnimation()
    {
        _playerAnimator.SetFloat("Speed", 1.0f, 0.05f, Time.deltaTime);
    }
    private void TurnOffMoveAnimation()
    {
        _playerAnimator.SetFloat("Speed", 0.0f, 0.05f, Time.deltaTime);
    }

    public void GetTrap()
    {
        if (pauseGame.resumeGame)
        {
            _playerAnimator.SetTrigger("Trap");
        }
    }
}
