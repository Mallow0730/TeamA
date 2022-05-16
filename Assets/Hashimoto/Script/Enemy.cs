using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    [Header("敵のHP")]public int enemyHP;
    [Header("SwordBoxをアタッチ")] public GameObject swordBox;
    void Start()
    {
        playerScript = GetComponent<Player>();
        

    }
    private void Update()
    {
        if (enemyHP <= 0)
        {
            BattleManager.battleInstance.experienceScore
                += BattleManager.battleInstance.experience;
            BattleManager.battleInstance.coinScore
                += BattleManager.battleInstance.coin;
            Debug.Log(BattleManager.battleInstance.experienceScore);
            Debug.Log(BattleManager.battleInstance.coinScore);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == swordBox)
        {
            enemyHP = enemyHP - BattleManager.battleInstance.enemyDamageTest;
            print("残りの敵のHP" + enemyHP);
        }
    }
}
