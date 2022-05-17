using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMove : MonoBehaviour
{
    
    [SerializeField]
    private PS4 _playerActionsAsset;
    private InputAction _move;
    //[Header("プレイヤーHP")] public int playerHP;
    private Rigidbody _rb;
    [SerializeField]
    private float _maxSpeed = 5f;
    private Vector3 _forceDirection = Vector3.zero;
    [SerializeField]
    private Camera _playerCamera;

    private Animator _animator;

    private Quaternion _targetRotation;

    private bool _canMove;
    public GameObject sword_Box;

    static readonly int hashAttackType = Animator.StringToHash("AttackType");
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
        _animator.SetFloat("speed", _rb.velocity.sqrMagnitude / _maxSpeed);

        //if (playerHP <= 0)
        //{
        //    BattleManager.battleInstance.player.SetActive(false);
        //    print("GameOver");
        //}
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
    public int AttackType
    {
        get => _animator.GetInteger(hashAttackType);
        set => _animator.SetInteger(hashAttackType,value);
    }


    private void Attack(InputAction.CallbackContext obj)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _animator.SetTrigger("Attack");
        AttackType = 0;
        sword_Box.SetActive(true);
        StartCoroutine(TimeLag());
    }
    IEnumerator TimeLag()
    {
        yield return new WaitForSeconds(3f);
        sword_Box.SetActive(false);
    }
    private void Attack2(InputAction.CallbackContext obj)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        AttackType = 1;
        
        _animator.SetTrigger("Attack");
        StartCoroutine(TimeLag());
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
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == enemyTag)
        //{
        //    playerHP -= BattleManager.battleInstance.playerAttack;
        //    //print("残りのプレイヤーのHP" + BattleManager.battleInstance.playerHP);
        //}
        //if (collision.gameObject.tag == bossTag)
        //{
        //    playerHP -= BattleManager.battleInstance.bossAttack;
        //}
    }

    private void Speed(InputAction.CallbackContext obj)//走るバグ
    {
        _animator.SetTrigger("speedUp");
        Debug.Log("a");
    }
    
    /*
    Animator animator;
    static readonly int hashAttackType = Animator.StringToHash("AttackType");
    static readonly int hashForwaed = Animator.StringToHash("speed");

    private void Awake()
    {
        TryGetComponent(out animator);
    }
    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        animator.SetFloat(hashForwaed, y, 0.1f, Time.deltaTime);
        animator.SetFloat(hashForwaed, x, 0.1f, Time.deltaTime);
    }
    public int AttackType
    {
        get => animator.GetInteger(hashAttackType);
        set => animator.SetInteger(hashAttackType,value);
    }
    */
}

