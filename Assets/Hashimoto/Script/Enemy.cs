using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player playerScript;
    string Sword = "Sword";

    public int enemyHP = 100;

    public int enemyDamage;
    //private int _enemyAttack;
    int pAttack;
    void Start()
    {
        Debug.Log(BattleManager.battleInstance.experience = Random.Range(100,200));
        
        pAttack = playerScript.PAttackScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Sword)
        {
            //enemyHP -= playerScript.playerAttack;
            enemyHP -= pAttack;
            print("残りの敵のHP" + enemyHP);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == Sword)
    //    {
    //        //enemyHP -= playerScript.playerAttack;
    //        enemyHP -= pAttack;
    //        print("残りの敵のHP" + enemyHP);
    //    }
    //}

    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public int EAttackScore
    {
        get
        {
            return enemyDamage;
        }
        set
        {
            enemyDamage = value;
        }
    }
}
