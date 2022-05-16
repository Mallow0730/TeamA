using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ショップのボタンに必要なスクリプト/summary>

public class ShopButton : MonoBehaviour
{
    /// <summary>最初の一回だけ反応する</summary>
    bool _firstPush = false;
    /// <summary>買うか買わないか確認するテキスト</summary>
    Canvas _questionText = null;

    public void BuyButton()
    {
        if(!_firstPush)
        {
            _firstPush = true;
            Debug.Log("a");
        }    
    }
}
