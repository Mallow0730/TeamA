using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player playerScript;
    string playertag = "Player";

    public int enemyHP = 100;

    public int enemyDamage;
    public int playerAttack;
    void Start()
    {
        Debug.Log(BattleManager.battleInstance.experience = Random.Range(100,200));
        playerScript = GetComponent<Player>();
    }
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == playertag)
    //    {
    //        enemyHP -= playerScript.playerAttack;
    //        print(enemyHP);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playertag)
        {
            //enemyHP -= playerScript.playerAttack;
            enemyHP -= 20;
            print(enemyHP);
        }
    }

    void Update()
    {
        
    }
}
