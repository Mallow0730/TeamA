using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyBase
{
    // <summary>ゲット出来るコイン量</summary>
    public int GetCoin => _getCoin;

    /// <summary>ゲット出来る経験値量</summary>
    public int GetExp => _getExp;

    /// <summary>ゲット出来るコイン量</summary>
    int _getCoin;

    /// <summary>ゲット出来る経験値量</summary>
    int _getExp;

    int _coin;
    int _exp;
    protected override void Start()
    {
        _coin = PlayerPrefs.GetInt("COINSCORE");
        _exp = PlayerPrefs.GetInt("EXPSCORE");
        base.Start();
    }
    protected override void Update() => base.Update();
    protected override void OnTriggerEnter(Collider other) => base.OnTriggerEnter(other);
    protected override void EnemyDamege()
    {
        base.EnemyDamege();
        _getCoin = Random.Range(1, 10);
        _getExp = Random.Range(20, 50);
        PlayerPrefs.SetInt("COINSCORE", GetCoin + _coin);
        PlayerPrefs.SetInt("EXPSCORE", GetExp + _exp);
        PlayerPrefs.Save();
    }
}
