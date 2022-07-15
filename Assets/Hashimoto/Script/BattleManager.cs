using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    /// <summary>バトルマネージャーのインタンス</summary>
    public static BattleManager battleInstance = null;

    /// <summary>プレイヤーのGameObject</summary>
    public GameObject Player => _player;

    public List <GameObject> AllEnemys => _allEnemys;

    public string EnemyTag => _enemyTag;

    [Header("プレイヤー設定")]

    /// <summary>プレイヤーのGameObject</summary>
    [SerializeField]
    [Header("プレイヤーのGameObject")]
    GameObject _player;

    [SerializeField]
    string _enemyTag = "Enemy";

    List <GameObject> _allEnemys = new List<GameObject>();

    private void Start()
    {
        _allEnemys = GameObject.FindGameObjectsWithTag(EnemyTag).ToList();
        print(_allEnemys.Count);
    }
    public void EnemyRemove(GameObject enemy)
    {
        _allEnemys.Remove(enemy);
        print(_allEnemys.Count);

        if (_allEnemys.Count <= 0)
        {
            print("GameClear");
        }
    }
}
