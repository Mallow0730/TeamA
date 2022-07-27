using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : SingletonMonoBehaviour<MoneyManager>
{
    int _coin;
    void Start()
    {
        _coin += GameManager.Instance.Coin;
    }

    void Update()
    {
        
    }
}
