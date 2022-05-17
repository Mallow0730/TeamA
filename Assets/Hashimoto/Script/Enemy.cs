using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("SwordBoxをアタッチ")] public GameObject swordBox;
    [Header("FootBoxをアタッチ")] public GameObject footBox;
    [Header("敵のHP")] public int enemyHP;
    void Start()
    {

    }
    private void Update()
    {
        if (enemyHP <= 0)
        {
            BattleManager.battleInstance.experienceScore
                += BattleManager.battleInstance.experience;
            BattleManager.battleInstance.coinScore
                += BattleManager.battleInstance.coin;
            //Debug.Log(BattleManager.battleInstance.experienceScore);
            //Debug.Log(BattleManager.battleInstance.coinScore);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == swordBox)
        {
            enemyHP -= BattleManager.battleInstance.playerAttack;
            //print("残りの敵のHP" + BattleManager.battleInstance.enemyHP);
        }
        if (other.gameObject == footBox)
        {
            enemyHP -= BattleManager.battleInstance.playerAttack;
            //print("残りの敵のHP" + BattleManager.battleInstance.enemyHP);
        }
    }
}
