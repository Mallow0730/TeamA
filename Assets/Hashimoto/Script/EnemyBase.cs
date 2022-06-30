using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    /// <summary>UIのスライダー</summary>
    public Slider Slider => _slider;

    /// <summary>UIのキャンバス</summary>
    public Canvas Canvas => _canvas;

    /// <summary>武器の攻撃力</summary>
    public int Attack => _attack;

    /// <summary>敵の体力</summary>
    public int EnemyHP => _enemyHP;

    /// <summar>現在の体力</summary>
    public int CurrentHP => _currentHP;

    /// <summary>EnemyのHP</summary>
    [SerializeField]
    [Header("敵のHP")]
    int _enemyHP;

    /// <summary>現在の体力</summary>
    int _currentHP;

    /// <summary>UIのスライダー</summary>
    [SerializeField]
    [Header("UIのスライダー")] 
    Slider _slider;

    /// <summary>UIのキャンバス</summary>
    [SerializeField]
    [Header("UIのキャンバス")] 
    Canvas _canvas;

    /// <summary>武器の攻撃力</summary>
    [SerializeField]
    [Header("武器の攻撃力")] 
    int _attack;

    [Header("アニメーション")]
    Animator _aniamtor;


    protected virtual void Start()
    {
        Slider.maxValue = EnemyHP;
        Slider.value = EnemyHP;
        _currentHP = _enemyHP;
        _aniamtor = GetComponent<Animator>();
        WeaponManager.Instance.WeaponAttack(_attack);
    }
    protected virtual void Update()
    {
        
        Canvas.transform.rotation = Camera.main.transform.rotation;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            EnemyDamege();
            _aniamtor.SetTrigger("Attack");
        }
    }
    protected virtual void EnemyDamege()
    {
        _enemyHP -= Attack;
        Slider.value = EnemyHP;
        if (EnemyHP <= 0)
        {
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
