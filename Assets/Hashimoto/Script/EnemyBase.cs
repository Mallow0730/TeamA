using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EnemyBase : MonoBehaviour
{
    /// <summary>UIのスライダー</summary>
    public Slider Slider => _slider;

    /// <summary>UIのキャンバス</summary>
    public Canvas Canvas => _canvas;

    /// <summary>敵の体力</summary>
    public int EnemyHP => _enemyHP;

    /// <summar>現在の体力</summary>
    public int CurrentHP => _currentHP;

    /// <summary>EnemyのHP</summary>
    [SerializeField]
    [Header("敵のHP")]
    int _enemyHP;

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

    /// <summary>現在の体力</summary>
    int _currentHP;

    protected virtual void Start()
    {
        Slider.maxValue = EnemyHP;
        Slider.value = EnemyHP;
        _currentHP = _enemyHP;
    }

    protected virtual void Update() => Canvas.transform.rotation = Camera.main.transform.rotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            EnemyDamege();
        }
    }
    protected virtual void EnemyDamege()
    {
        _enemyHP -= WeaponManager.Instance.AllAttacks.First(x => x.Name == "刀").Attack;
        print(EnemyHP);
        Slider.value = EnemyHP;
        if (EnemyHP <= 0)
        {
            BattleManager.Instance.EnemyRemove(gameObject);
            Destroy(gameObject);
        }
    }
}
