using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager battleInstance = null;
    bool _gameOver = false;
    [Header("プレイヤー設定")]
    [Header("プレイヤーアタッチ")] public GameObject player;
    

    [Header("得られるもの")]
    [Header("経験値")] public int experience;
    [Header("コイン")] public int coin;

    [Header("得たもの")]
    [Header("得たもの")] public int experienceScore;
    [Header("得たもの")] public int coinScore;


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
        
    }

    void Update()
    {
        if (player == null)
        {
            _gameOver = true;
            Debug.Log("GameOver");
        }
    }
}
