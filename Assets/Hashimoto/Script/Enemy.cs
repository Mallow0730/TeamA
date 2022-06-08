using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    /// <summary>ゲット出来るコイン量</summary>
    public int GetCoin { get => _getCoin; set => _getCoin = value; }

    /// <summary>ゲット出来る経験値量</summary>
    public int GetExp { get => _getExp; set => _getExp = value; }

    /// <summary>UIのスライダー</summary>
    public Slider Slider { get => _slider;}

    /// <summary>UIのキャンバス</summary>
    public Canvas Canvas { get => _canvas;}

    /// <summary>敵のアタック</summary>
    public int Attack { get => _attack;}

    /// <summary>敵の体力</summary>
    public int EnemyHP { get => _enemyHP; set => _enemyHP = value; }

    /// <summary>武器Script</summary>
    public Weapon Weapon { get => _weapon;}

    /// <summary>シーンScript</summary>
    [SerializeField] Scenemanager _sceneManager;

    /// <summary>EnemyのHP</summary>
    [SerializeField]
    [Header("敵のHP")]
    int _enemyHP;

    /// <summary>武器のスクリプト</summary>
    [SerializeField]
    [Header("武器のスクリプト")] 
    Weapon _weapon;

    /// <summary>ゲット出来るコイン量</summary>
    [SerializeField]
    [Header("ゲット出来るコイン量")] 
    int _getCoin;

    /// <summary>ゲット出来る経験値量</summary>
    [SerializeField]
    [Header("ゲット出来る経験値量")] 
    int _getExp;

    /// <summary>UIのスライダー</summary>
    [SerializeField]
    [Header("UIのスライダー")] 
    Slider _slider;

    /// <summary>UIのキャンバス</summary>
    [SerializeField]
    [Header("UIのキャンバス")] 
    Canvas _canvas;

    /// <summary>敵の攻撃力</summary>
    [SerializeField]
    [Header("攻撃力")] 
    int _attack;

    void Start()
    {
        Slider.value = 100;
        _enemyHP = 100;
    }
    private void Update()
    {
        
        Canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            EnemyKill();
        }
    }
    public void EnemyKill()
    {
        EnemyHP -= Weapon.Attack;
        if (EnemyHP <= 0)
        {
            GetCoin = Random.Range(1, 10);
            GetExp = Random.Range(20, 50);
            GameManager.instance.Coin += GetCoin;
            GameManager.instance.Exp += GetExp;
            PlayerPrefs.SetInt("COINSCORE", GameManager.instance.Coin);
            PlayerPrefs.SetInt("EXPSCORE", GameManager.instance.Exp);
            PlayerPrefs.Save();
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
