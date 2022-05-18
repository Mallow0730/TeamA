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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BattleManager.battleInstance.enemyHP -= _attack;

            Debug.Log("当たった");
            Debug.Log(BattleManager.battleInstance.enemyHP);
        }
    }
}
