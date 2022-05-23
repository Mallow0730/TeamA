using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 

    public int _attack;


    void Start()
    {

    }

    void Update()
    {
        //if (BattleManager.battleInstance.enemyHP <= 0)
        //{
        //    BattleManager.battleInstance.experienceScore
        //        += BattleManager.battleInstance.experience;
        //    BattleManager.battleInstance.coinScore
        //        += BattleManager.battleInstance.coin;
        //    //Debug.Log(BattleManager.battleInstance.experienceScore);
        //    //Debug.Log(BattleManager.battleInstance.coinScore);
        //    //Destroy(this.gameObject);
        //    Debug.Log("EnemyHP == 0");

        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("当たった");
            //Debug.Log(BattleManager.battleInstance.enemyHP);
        //}
    }
}
