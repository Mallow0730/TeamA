using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;

public class Player : MonoBehaviour
{
    /// <summary>Playerの移動速度</summary>
    public float MaxSpeed => _maxSpeed;

    /// <summary>PlayerのHP</summary>
    public int PlayerHP => _playerHP;

    /// <summary>EnemyのScript</summary>
    public EnemyBase EnemyScript => _enemyScript;

    /// <summary>武器</summary>
    public List<GameObject> Weapon => _weapon;

    public List<string> EnemyTags => _enemyTags;

    /// <summary>PlayerHPバー</summary>
    public Slider PlayerHpSlider => _playerHpSlider;

    ///<summary>HPの回復量</summary>
    public int HpHealth => _hpHealth;


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

    /// <summary>PlayerHP</summary>
    [SerializeField]
    [Header("プレイヤーHP")]
    int _playerHP;

    ///<summary>PlayerHPバー</summary>
    [SerializeField]
    [Header("PlayerHPバー")]
    Slider _playerHpSlider;

    ///<summary>HPの回復量</summary>
    [SerializeField]
    [Header("HPの回復量")]
    int _hpHealth;

    /// <summary>EnemyScript</summary>
    [SerializeField] 
    [Header("EnemyScript")]
    EnemyBase _enemyScript;

    List<ItemBase> _items = new List<ItemBase>();


    const float X_MOVE = -960f;
    const float SECONDS = 1f;

    [SerializeField]
    List<GameObject> _weapon = new List<GameObject>();

    List<string> _enemyTags = new List<string>();

    const string GAMEOVER_SCENE = "GameOverScene";
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerActionsAsset = new PS4();
        _canMove = true;
        _targetRotation = transform.rotation;
    }

    private void Start()
    {
        //GameObject.FindGameObjectsWithTag("Enemy").Length
        Scenemanager.Instance.FadeIn(X_MOVE, SECONDS);
        _playerHpSlider.maxValue = PlayerHP;
        
    }

        private void OnEnable()
    {
        _playerActionsAsset.Player.Attack.started += Attack;
        _playerActionsAsset.Player.Block.started += Attack2;
        _playerActionsAsset.Player.Jump.started += Jump;

        _move = _playerActionsAsset.Player.Move;
        _playerActionsAsset.Player.Enable();
    }

    

    private void OnDisable()
    {
        _playerActionsAsset.Player.Attack.started -= Attack;
        _playerActionsAsset.Player.Block.started -= Attack2;
        _playerActionsAsset.Player.Jump.started -= Jump;

        _playerActionsAsset.Player.Disable();
    }
    void Update()
    {
        _animator.SetFloat("speed", _rb.velocity.sqrMagnitude / MaxSpeed);
        //_allEnemys.Remove(_allEnemys[0]);//removeでリストから除外する
        PlayerKill();
    }
    public void PlayerKill()
    {
        if (PlayerHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
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

    void Attack(InputAction.CallbackContext obj)
    {
        _weapon[0].SetActive(true);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _animator.SetTrigger("attack");
    }

    void Attack2(InputAction.CallbackContext obj)
    {
        _weapon[1].SetActive(true);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _animator.SetTrigger("kick");
    }

    void Jump(InputAction.CallbackContext obj)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _animator.SetTrigger("jump");
    }

    Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = _playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = _playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    void SpeedCheck()
    {
        Vector3 playerVelocity = _rb.velocity;
        playerVelocity.y = 0;

        if (playerVelocity.sqrMagnitude > MaxSpeed * MaxSpeed)
        {
            _rb.velocity = playerVelocity.normalized * MaxSpeed;
        }
    }

    void LookAt()
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyAttack();
        }
    }

    public void EnemyAttack()
    {
        _playerHP -= WeaponManager.Instance.AllAttacks.First(x => x.WeaponName == "手").Attack;
        _playerHpSlider.value = PlayerHP;
    }
    public void HPItem()
    {
        _items.Add(new ItemPortion());
        if (PlayerHP == 100)
        {
            print("回復しても意味ないよ");
        }
        if (PlayerHP < 100)
        {
            _playerHP += HpHealth;
            _playerHpSlider.value = PlayerHP;
            if (PlayerHP >= 100)
            {
                _playerHP = 100;
            }
        }
        //_playerHP += 25;
        //_playerHP = (int)PlayerHpSlider.value;
        UseItem(0);
    }

    private void UseItem(int index)
    {
        ItemBase useItem = _items[index];
        print(index + 1 + "つ目のアイテムを使った");
        useItem.Use();
    }

    public void WeaponFalse() => _weapon.ForEach(x => x.gameObject.SetActive(false));
}
