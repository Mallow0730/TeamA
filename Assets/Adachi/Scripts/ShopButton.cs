using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>ショップのボタンに必要なスクリプト/summary>

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    [Header("商品名")]
    string _gearName;

    [SerializeField]
    [Header("値段")]
    int _price;

    /// <summary>買うか買わないか確認するパネル</summary>
    [SerializeField]
    [Header("アイテムを買うか買わないか確認するパネル")]
    Image _shopPanel = null;

    /// <summary>パネルにあるボタン以外の全てのボタン</summary>
    [SerializeField]
    [Header("パネルの後ろにある全ボタン")]
    List<Button> _deleteButtons = new List<Button>();

    //ボタンを押したらパネルを表示する
    public void Click()
    {
        _deleteButtons.ForEach(button => { button.interactable = false; });//ボタンを押せなくする
        _shopPanel.gameObject.SetActive(true);//パネルを表示する
        Debug.Log("Click");
    }

    //ボタンを押したらパネルを非表示にする
    public void Cancel()
    {
        _deleteButtons.ForEach(button => { button.interactable = true; });//ボタンを押せるようにする
        _shopPanel.gameObject.SetActive(false);//パネルを非表示する
        Debug.Log("Cancel");
    }

    public void Buy()
    {
        if(PlayerPrefs.GetInt("COINSCORE") >= _price)
        {
            //お金を減らす処理をかく(所持金 - price)
            PlayerPrefs.SetInt("COINSCORE" ,-_price);
            Debug.Log("を買いました");
        }
        else
        {
            Debug.Log("お金が足りません");
        }
    }
}
