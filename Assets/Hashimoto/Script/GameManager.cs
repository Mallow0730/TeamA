using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int Coin { get => _coin; set => _coin = value; }//コインの合計値
    public int Exp { get => _exp; set => _exp = value; }//経験値の合計値

    /// <summary>コインの合計値</summary>
    [Header("コインの合計値")]
    int _coin;

    /// <summary>経験値の合計値</summary>
    [Header("経験値の合計値")]
    int _exp;

    /// <summary>コインの最小値</summary>
    [SerializeField]
    [Header("コインの最小値")]
    int _coinMini;

    /// <summary>コインの最大値</summary>
    [SerializeField]
    [Header("コインの最大値")]
    int _coinMax;


    /// <summary>経験値の最小値</summary>
    [SerializeField]
    [Header("経験値の最小値")]
    int _expMini;

    /// <summary>経験値の最大値</summary>
    [SerializeField]
    [Header("経験値の最大値")]
    int _expMax;


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
        Coin = PlayerPrefs.GetInt("COINSCORE");
        Exp =  PlayerPrefs.GetInt("EXPSCORE");
        Debug.Log(Coin);
        Debug.Log(Exp);
    }

    void Update()
    {
        
    }
}
