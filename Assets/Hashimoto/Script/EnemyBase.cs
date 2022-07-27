using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
/// <summary>
/// Enemyの基底クラス
/// </summary>
public class EnemyBase : MonoBehaviour
{
    /// <summary>UIのスライダー</summary>
    public Slider EnemySlider => _enemySlider;

    /// <summary>UIのキャンバス</summary>
    public Canvas Canvas => _canvas;

    /// <summary>敵の体力</summary>
    public int EnemyHP => _enemyHP;

    /// <summar>現在の体力</summary>
    public int CurrentHP => _currentHP;

    /// <summary>ダメージ量</summary>
    public int Damage => _damage;

    /// <summary>EnemyのHP</summary>
    [SerializeField]
    [Header("敵のHP")]
    int _enemyHP;

    /// <summary>UIのスライダー</summary>
    [SerializeField]
    [Header("UIのスライダー")] 
    Slider _enemySlider;

    /// <summary>UIのキャンバス</summary>
    [SerializeField]
    [Header("UIのキャンバス")] 
    Canvas _canvas;

    /// <summary>武器の攻撃力</summary>
    [SerializeField]
    [Header("武器の攻撃力")] 
    int _attack;

    /// <summary>ダメージ量</summary>
    int _damage;

    /// <summary>現在の体力</summary>
    int _currentHP;

    protected virtual void Start()
    {
        EnemySlider.maxValue = EnemyHP;
        EnemySlider.value = EnemyHP;
        _currentHP = _enemyHP;
    }

    protected virtual void Update()
    {
        Canvas.transform.rotation = Camera.main.transform.rotation;
        EnemyDamege();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamage player))
        {
            player.GetDamage(Damage);
        }
    }
    protected virtual void EnemyDamege()
    {
        if (EnemyHP <= 0)
        {
            BattleManager.Instance.EnemyRemove(gameObject);
            Destroy(gameObject);
        }
    }
    public void HPProperty(int damage) => _enemyHP -= damage;
}
