using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    /// <summary>コインの合計値</summary>
    public int Coin => _coin;//コインの合計値

    /// <summary>コインの合計値</summary>
    public int Exp => _exp;//経験値の合計値


    /// <summary>コインの合計値</summary>
    [Header("コインの合計値")]
    int _coin;

    /// <summary>経験値の合計値</summary>
    [Header("経験値の合計値")]
    int _exp;

    public int ChangeCoin(int coin) => _coin += coin;
}
