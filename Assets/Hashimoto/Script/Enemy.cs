using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    //[Header("SwordBoxをアタッチ")] public GameObject swordBox;
    //[Header("FootBoxをアタッチ")] public GameObject footBox;
    //string tagname1 = "Sword";
    //string tagname2 = "Foot";
    //[Header("敵のHP")] public int enemyHP;
    int currentHP;

    public Slider slider;
    public Canvas canvas;


    void Start()
    {
        slider.value = 1;
        currentHP = BattleManager.battleInstance.enemyHP;
    }
    private void Update()
    {
        if (currentHP <= 0)
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
        canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Playerが入ってきた");//追跡機能
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
