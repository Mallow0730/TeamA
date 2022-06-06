using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    /// <summary>バトルマネージャーのインタンス</summary>
    public static BattleManager battleInstance = null;

    /// <summary>ボスのGameObject</summary>
    public GameObject Boss { get => _boss; set => _boss = value; }

    /// <summary>プレイヤーのGameObject</summary>
    public GameObject Player { get => _player; set => _player = value; }

    /// <summary>Enemyの配列</summary>
    //public GameObject[] Enemies { get => _enemies; set => _enemies = value; }


    [Header("プレイヤー設定")]

    /// <summary>プレイヤーのGameObject</summary>
    [SerializeField]
    [Header("プレイヤーのGameObject")]
    GameObject _player;

    //[Header("敵設定")]

    /// <summary>Enemy配列</summary>
    [SerializeField]
    [Header("Enemyの配列")]
    GameObject[] _enemies;

    List<GameObject> _e = new List<GameObject>();//EnemyList

    /// <summary>ボスのGameObject</summary>
    [SerializeField]
    [Header("ボスのGameObject")]
    GameObject _boss;

    /// <summary>一回だけの行動</summary>
    bool isFirstAction = false;


    private void Awake()
    {
        if (battleInstance == null)
        {
            battleInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        //Boss = GameObject.FindGameObjectWithTag("BigBoss");
        Boss.SetActive(false);
        //Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //_player = GameObject.Find("Player");
        //var a = GameObject.FindWithTag("Enemy");
        //_e.Add(a);
        //_e.Remove(a);
        //_e.Clear();
        //_e.ForEach(x => x.transform.position = new Vector3(0,0,0));
        //foreach (var b in _e)
        //{
        //    b.transform.position = new Vector3(0,0,0);
        //}
    }

    void Update()
    {
        Debug.Log(_enemies.Length);
        if (_enemies.Length == 0)
        {
            Debug.Log("ラスボス出現!!");
            Boss.SetActive(true);
        }
    }
}
