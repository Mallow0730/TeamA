using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public int Coin => _coin;

    int _coin;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public int ChangeCoin(int coin) => _coin += coin;
}
