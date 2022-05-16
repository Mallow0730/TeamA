using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager battleInstance = null;
    [Header("プレイヤー設定")]
    [Header("プレイヤーアタッチ")] public GameObject player;
    [Header("プレイヤーの攻撃力")] public int playerAttack;
    

    [Header("得られるもの")]
    [Header("経験値")] public int experience;
    [Header("コイン")] public int coin;

    [Header("得たもの")]
    [Header("得たもの")] public int experienceScore;
    [Header("得たもの")] public int coinScore;

    [Header("敵設定")]
    
    [Header("敵の攻撃力")] public int enemyAttack;

    public GameObject[] enemyFolder;
    public GameObject boss;
    
    [Header("ボスの攻撃力")] public int bossAttack;

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
        boss.SetActive(false);
    }

    void Update()
    {
        enemyFolder = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (!isFirstAction && enemyFolder.Length == 0)
        {
            isFirstAction = true;
            Debug.Log("ラスボス出現!!");
            boss.gameObject.SetActive(true);
            boss = GameObject.FindGameObjectWithTag("BigBoss");
        }
    }
}
