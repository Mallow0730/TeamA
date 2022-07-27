using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;
/// <summary>
/// Playerの神クラス
/// </summary>
public class Player : MonoBehaviour, IDamage
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

    /// <summary>体力スライダー</summary>
    public Slider HPSlider => _HPSlider;


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

    /// <summary>体力スライダー</summary>
    [SerializeField]
    [Header("体力スライダー")]
    Slider _HPSlider;

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

    ///<summary>ダメージ力</summary>
    public int Damage => _damage;

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

    ///<summary>ダメージ力</summary>
    [SerializeField]
    [Header("ダメージ力")]
    int _damage;

    /// <summary>EnemyScript</summary>
    [SerializeField]
    [Header("EnemyScript")]
    EnemyBase _enemyScript;

    List<ItemBase> _items = new List<ItemBase>();


    const float X_MOVE = 960f;
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
        Scenemanager.Instance.FadeIn(-X_MOVE, SECONDS);
        _playerHpSlider.maxValue = PlayerHP;
    }

    private void OnEnable()
    {
        _playerActionsAsset.Player.Attack.started += Attack;
        _playerActionsAsset.Player.Block.started += Attack2;
        _playerActionsAsset.Player.Jump.started += Jump;
        _playerActionsAsset.Player.Item.started += Item;

        _move = _playerActionsAsset.Player.Move;
        _playerActionsAsset.Player.Enable();
    }



    private void OnDisable()
    {
        _playerActionsAsset.Player.Attack.started -= Attack;
        _playerActionsAsset.Player.Block.started -= Attack2;
        _playerActionsAsset.Player.Jump.started -= Jump;
        _playerActionsAsset.Player.Item.started -= Item;

        _playerActionsAsset.Player.Disable();
    }
    void Update()
    {
        _animator.SetFloat("speed", _rb.velocity.sqrMagnitude / MaxSpeed);
        PlayerKill();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamage enemy))
        {
            enemy.GetDamage(Damage);
        }
    }
    public void GetDamage(int d)
    {
        HPProperty(d);
        PlayerHpSlider.value -= d;
    }
    public void PlayerKill()
    {
        if (PlayerHP <= 0)
        {
            gameObject.SetActive(false);
            Scenemanager.Instance.FadeOut(GAMEOVER_SCENE, +X_MOVE, SECONDS);
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
    private void Item(InputAction.CallbackContext obj)
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
        UseItem(0);
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

    public void Change() => _canMove = !_canMove;
    private void UseItem(int index)
    {
        ItemBase useItem = _items[index];
        print(index + 1 + "つ目のアイテムを使った");
        useItem.Use();
    }
    /// <summary>アニメーターで実装</summary>
    public void WeaponFalse() => _weapon.ForEach(x => x.gameObject.SetActive(false));

    public void HPProperty(int hp) => _playerHP -= hp;
}
