using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// バトルマネージャー
/// クリア条件もここに書いてあるよ
/// </summary>
public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    /// <summary>バトルマネージャーのインタンス</summary>
    public static BattleManager battleInstance = null;

    /// <summary>プレイヤーのGameObject</summary>
    public GameObject Player => _player;

    /// <summary>全ての敵のリスト</summary>
    public List <GameObject> AllEnemys => _allEnemys;

    /// <summary>敵のタグ</summary>
    public string EnemyTag => _enemyTag;

    /// <summary>ゲット出来るコイン量</summary>
    public int Coin => _coin;

    [Header("プレイヤー設定")]

    /// <summary>プレイヤーのGameObject</summary>
    [SerializeField]
    [Header("プレイヤーのGameObject")]
    GameObject _player;

    /// <summary>敵のタグ</summary>
    [SerializeField]
    string _enemyTag = "Enemy";

    /// <summary>ゲット出来るコイン量</summary>
    int _coin;

    /// <summary>ミニコイン固定値</summary>
    const int MINICOIN = 100;

    /// <summary>マックスコイン固定値</summary>
    const int MAXCOIN = 500;

    List <GameObject> _allEnemys = new List<GameObject>();

    private void Start()
    {
        _allEnemys = GameObject.FindGameObjectsWithTag(EnemyTag).ToList();
        print(_allEnemys.Count);
        _coin = Random.Range(MINICOIN, MAXCOIN);
    }
    public void EnemyRemove(GameObject enemy)
    {
        _allEnemys.Remove(enemy);
        print(_allEnemys.Count);

        if (_allEnemys.Count == 0)
        {
            print("GameClear");
            GameManager.Instance.ChangeCoin(Coin);
        }
    }
}
