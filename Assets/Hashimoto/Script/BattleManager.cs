using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    /// <summary>バトルマネージャーのインタンス</summary>
    public static BattleManager battleInstance = null;

    /// <summary>プレイヤーのGameObject</summary>
    public GameObject Player { get => _player; set => _player = value; }

    /// <summary>ボス</summary>
    public GameObject Boss { get => _boss; set => _boss = value; }

    /// <summary>ボスタグ</summary>
    public string BossName { get => _bossName; set => _bossName = value; }


    [Header("プレイヤー設定")]

    /// <summary>プレイヤーのGameObject</summary>
    [SerializeField]
    [Header("プレイヤーのGameObject")]
    GameObject _player;

    /// <summary>ボス</summary>
    GameObject _boss;

    /// <summary>ボスタグ</summary>
    string _bossName = "BigBoss";


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
        Boss = GameObject.FindGameObjectWithTag(BossName);
    }

    void Update()
    {
        if (Boss == false)
        {
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("COINSCORE"));
            Debug.Log(PlayerPrefs.GetInt("EXPSCORE"));
            //テストしてないからテストプレイよろ
            Debug.Log("GameClear");
            //クリアシーンに飛ぶ
        }
    }
}
