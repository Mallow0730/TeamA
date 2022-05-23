using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("ボスをアタッチ")]public GameObject boss;

    [Header("ボスのHP")] public int bossHP;
    public GameObject swordBox;
    public GameObject footBox;
    [SerializeField] Weapon _weapon;
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
            Debug.Log(BattleManager.battleInstance.coinScore);
            Debug.Log(BattleManager.battleInstance.experienceScore);
            PlayerPrefs.Save();
            Debug.Log("GameClear");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            bossHP -= _weapon._attack = 50;
            //print("残りの敵のHP" + BattleManager.battleInstance.enemyHP);
        }
    }
}
