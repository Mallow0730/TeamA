using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : SingletonMonoBehaviour<ShopUIManager>
{
    [SerializeField]
    [Header("所持金のテキスト")]
    Text _moneyText;

    [SerializeField]
    [Header("ショップの名前のテキスト")]
    Text _shopNameText;

    [SerializeField]
    [Header("ショップメニューのボタン")]
    List<Button> _menuButton = new List<Button>();

    [SerializeField]
    [Header("左下に表示するパネル")]
    Image _displayPanel;

    [SerializeField]
    [Header("アイテム説明のパネル")]
    Image _ItemDescriptionPanel;

    

    void Start()
    {
        _shopNameText.text = 0.ToString();
    }

    void Update()
    {
           
    }

    /// <summary>ショップメニューを表示</summary>
    public void DisplayShopMenu()
    {
        _moneyText.gameObject.SetActive(true);
        _shopNameText.gameObject.SetActive(true);
        _menuButton.ForEach(menuButton => {menuButton.gameObject.SetActive(true);});
        _displayPanel.gameObject.SetActive(true);
    }

    /// <summary>ボタンを押すと次のウィンドウを表示する際に今のボタンを非表示にする</summary>
    public void NextWindow(List<Button> deleteButtons)
    {
        deleteButtons.ForEach(button => { button.gameObject.SetActive(false); });//ボタンを非表示
    }

    public void Back()
    {

    }


}
