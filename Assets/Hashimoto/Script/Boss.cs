﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("ボスをアタッチ")]public GameObject boss;

    [Header("ボスのHP")] public int bossHP;
    public GameObject swordBox;
    public GameObject footBox;
    void Start()
    {
        
    }

    void Update()
    {
        if (bossHP <= 0)
        {
            boss.SetActive(false);
            BattleManager.battleInstance.coinScore 
                += BattleManager.battleInstance.coin * 2;
            BattleManager.battleInstance.experienceScore
                += BattleManager.battleInstance.experience * 2;
            PlayerPrefs.SetInt("COINSCORE", BattleManager.battleInstance.coinScore);
            PlayerPrefs.SetInt("EXPSCORE", BattleManager.battleInstance.experienceScore);
            PlayerPrefs.Save();
            Debug.Log("GameClear");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == swordBox)
        {
            bossHP -= BattleManager.battleInstance.playerAttack;
            //print("残りの敵のHP" + BattleManager.battleInstance.enemyHP);
        }
        if (other.gameObject == footBox)
        {
            bossHP -= BattleManager.battleInstance.playerAttack;
            //print("残りの敵のHP" + BattleManager.battleInstance.enemyHP);
        }
    }
}
