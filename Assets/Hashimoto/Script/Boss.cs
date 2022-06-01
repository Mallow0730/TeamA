using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    /// <summary>ゲット出来るコイン量</summary>
    public int GetCoin { get => _getCoin; set => _getCoin = value; }

    /// <summary>ゲット出来る経験値量</summary>
    public int GetExp { get => _getExp; set => _getExp = value; }

    /// <summary>ボスの体力</summary>
    public int BossHP { get => _bossHP; set => _bossHP = value; }

    /// <summary>ボスの体力</summary>
    [SerializeField]
    [Header("ボスのHP")]
    int _bossHP;

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


    void Start()
    {
        _bossHP = 200;
    }

    void Update()
    {
        if (BossHP <= 0)
        {
            this.gameObject.SetActive(false);
            GameManager.instance.Coin += GetCoin;
            GameManager.instance.Exp += GetExp;
            PlayerPrefs.SetInt("COINSCORE", GameManager.instance.Coin);
            PlayerPrefs.SetInt("EXPSCORE", GameManager.instance.Exp);
            PlayerPrefs.Save();
            Debug.Log("GameClear");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            BossHP -= _weapon.Attack = 50;
            //print("残りの敵のHP" + BattleManager.battleInstance.enemyHP);
        }
    }
}
