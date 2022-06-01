using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /// <summary>Playerの移動速度</summary>
    public float MaxSpeed => _maxSpeed;

    /// <summary>PlayerのHP</summary>
    public int PlayerHP { get => _playerHP; set => _playerHP = value; }

    /// <summary>EnemyのScript</summary>
    public Enemy EnemyScript { get => _enemyScript; set => _enemyScript = value; }


    /// <summary>PS4コントローラー</summary>
    [SerializeField]
    [Header("PS4コントローラー")]
    private PS4 _playerActionsAsset;

    /// <summary>カメラアングル</summary>
    [SerializeField]
    [Header("歩くスピード")]
    private Camera _playerCamera;

    
    /// <summary>歩くスピード</summary>
    [SerializeField]
    [Header("歩くスピード")]
    float _maxSpeed = 5f;

    /// <summary>InputAction</summary>
    InputAction _move;

    /// <summary>Rigidbody</summary>
    Rigidbody _rb;

    /// <summary>Vector3</summary>
    Vector3 _forceDirection = Vector3.zero;

    /// <summary>アニメーション</summary>
    Animator _animator;

    /// <summary>視点移動</summary>
    Quaternion _targetRotation;

    /// <summary>動くかの判別</summary>
    bool _canMove;

    /// <summary>敵のタグ</summary>
    string _enemyTag = "Enemy";

    /// <summary>ボスのタグ</summary>
    string _bossTag = "BigBoss";

    /// <summary>PlayerHP</summary>
    [SerializeField]
    [Header("プレイヤーHP")]
    int _playerHP;

    /// <summary>EnemyScript</summary>
    [SerializeField] 
    [Header("EnemyScript")]
    Enemy _enemyScript;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerActionsAsset = new PS4();
        _canMove = true;
        _targetRotation = transform.rotation;
    }

    private void OnEnable()
    {
        _playerActionsAsset.Player.Attack.started += Attack;
        _playerActionsAsset.Player.Block.started += Attack2;
        _playerActionsAsset.Player.Jump.started += Jump;

        //_playerActionsAsset.Player.SpeedUp.started += Speed;
        //_playerActionsAsset.Player.SpeedUp.canceled += Speed;

        _move = _playerActionsAsset.Player.Move;
        _playerActionsAsset.Player.Enable();
    }

    

    private void OnDisable()
    {
        _playerActionsAsset.Player.Attack.started -= Attack;
        _playerActionsAsset.Player.Block.started -= Attack2;
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
        _animator.SetFloat("speed", _rb.velocity.sqrMagnitude / MaxSpeed);

        if (PlayerHP <= 0 )
        {
            BattleManager.battleInstance.Player.SetActive(false);
            //print("GameOver");
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
    }
    private void Attack2(InputAction.CallbackContext obj)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _animator.SetTrigger("kick");
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
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

        if (playerVelocity.sqrMagnitude > MaxSpeed * MaxSpeed)
        {
            _rb.velocity = playerVelocity.normalized * MaxSpeed;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _enemyTag)
        {
            PlayerHP -= EnemyScript.Attack;
            Debug.Log(PlayerHP);
            //print("残りのプレイヤーのHP" + BattleManager.battleInstance.playerHP);
        }
        if (collision.gameObject.tag == _bossTag)
        {
            PlayerHP -= EnemyScript.Attack;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        //if (other.gameObject.tag == enemyTag)
        //{
        //    playerHP -= BattleManager.battleInstance.enemyAttack;
        //    Debug.Log(playerHP);
        //    //print("残りのプレイヤーのHP" + BattleManager.battleInstance.playerHP);
        //}
        //if (other.gameObject.tag == bossTag)
        //{
        //    playerHP -= BattleManager.battleInstance.bossAttack;
        //}
        */
        
    }

    private void Speed(InputAction.CallbackContext obj)//走るバグ
    {
        _animator.SetTrigger("speedUp");
        Debug.Log("a");
    }
}
