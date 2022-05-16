using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyScript;
    private PS4 _playerActionsAsset;
    private InputAction _move;

    private Rigidbody _rb;
    [SerializeField]
    private float _maxSpeed = 5f;
    private Vector3 _forceDirection = Vector3.zero;
    [SerializeField]
    private Camera _playerCamera;

    private Animator _animator;

    private Quaternion _targetRotation;

    private bool _canMove;
    string enemyTag = "Enemy";

    public GameObject[] enemyfolder;

    public Text expText;

    public GameObject sword_Box;
    [SerializeField] private int eAttack;

    //Enemy enemy = new Enemy();

    //[Header("プレイヤーアタッチ")] public GameObject player;
    [Header("プレイヤーHP")] public int playerHp;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerActionsAsset = new PS4();
        _canMove = true;
        _targetRotation = transform.rotation;
        enemyScript = GetComponent<Enemy>();
        //eAttack = enemyScript.EAttackScore;
    }

    private void OnEnable()
    {
        _playerActionsAsset.Player.Attack.started += Attack;
        _playerActionsAsset.Player.Block.started += Bclck;
        _playerActionsAsset.Player.Block.canceled += Bclck;
        _playerActionsAsset.Player.Jump.started += Jump;

        //_playerActionsAsset.Player.SpeedUp.started += Speed;
        //_playerActionsAsset.Player.SpeedUp.canceled += Speed;

        _move = _playerActionsAsset.Player.Move;
        _playerActionsAsset.Player.Enable();
    }

    

    private void OnDisable()
    {
        _playerActionsAsset.Player.Attack.started -= Attack;
        _playerActionsAsset.Player.Block.started -= Bclck;
        _playerActionsAsset.Player.Block.canceled -= Bclck;
        _playerActionsAsset.Player.Jump.started -= Jump;

        //_playerActionsAsset.Player.SpeedUp.started -= Speed;
        //_playerActionsAsset.Player.SpeedUp.canceled -= Speed;

        _playerActionsAsset.Player.Disable();
    }

    

    void Start()
    {
        
    }

    void Update()
    {
        _animator.SetFloat("speed", _rb.velocity.sqrMagnitude / _maxSpeed);

        if (playerHp <= 0 )
        {
            BattleManager.battleInstance.player.SetActive(false);
            print("GameOver");
        }
    }

    private void FixedUpdate()
    {
        SpeedCheck();

        if (!_canMove)
        {
            return;
        }

        _forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(_playerCamera);
        _forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(_playerCamera);

        _rb.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        LookAt();
    }



    private void Attack(InputAction.CallbackContext obj)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        _animator.SetTrigger("attack");
        sword_Box.SetActive(true);
        StartCoroutine(SwordBoxFalse());
    }
    IEnumerator SwordBoxFalse()
    {
        yield return new WaitForSeconds(0.7f);
        sword_Box.SetActive(false);
    }
    private void Bclck(InputAction.CallbackContext obj)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        _animator.SetBool("block", !_animator.GetBool("block"));

        Change();
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("jump");
    }


    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = _playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = _playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
    private void SpeedCheck()
    {
        Vector3 playerVelocity = _rb.velocity;
        playerVelocity.y = 0;

        if (playerVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
        {
            _rb.velocity = playerVelocity.normalized * _maxSpeed;
        }
    }
    private void LookAt()
    {
        Vector3 direction = _rb.velocity;
        direction.y = 0;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            _targetRotation = Quaternion.LookRotation(direction);
            _rb.rotation = Quaternion.RotateTowards(_rb.rotation, _targetRotation, 900 * Time.deltaTime);
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
        }
    }
    public void Change()
    {
        _canMove = !_canMove;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == enemyTag)
    //    {
    //        //Unityの方のTag消しとけ
    //        playerHp -= enemyScript.enemyAttack;
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        //eAttack = enemyScript.EAttackScore;
        
        if (collision.gameObject.tag == enemyTag)
        {
            //Enemy enemy = new Enemy();
            //eAttack = enemyScript.EAttackScore;
            playerHp = playerHp - BattleManager.battleInstance.playerDamageTest;
            print("残りのプレイヤーのHP" + playerHp);
        }
    }

    private void Speed(InputAction.CallbackContext obj)//走るバグ
    {
        _animator.SetTrigger("speedUp");
        Debug.Log("a");
    }
    //public int PAttackScore
    //{
    //    get
    //    {
    //        return playerAttack;
    //    }
    //    private set
    //    {
    //        playerAttack = value;
    //    }
    //}

    //public int PlayerAttack { get => playerAttack; set => playerAttack = value; }
}
