using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public static GameManager instance = null;

    /// <summary>コインの合計値</summary>
    public int Coin { get => _coin; set => _coin = value; }//コインの合計値

    /// <summary>コインの合計値</summary>
    public int Exp { get => _exp; set => _exp = value; }//経験値の合計値


    /// <summary>コインの合計値</summary>
    [Header("コインの合計値")]
    int _coin;

    /// <summary>経験値の合計値</summary>
    [Header("経験値の合計値")]
    int _exp;

    
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
        PlayerPrefs.DeleteAll();
        Coin = PlayerPrefs.GetInt("COINSCORE");
        Exp =  PlayerPrefs.GetInt("EXPSCORE");
        Debug.Log(Coin);
        Debug.Log(Exp);
    }
}
