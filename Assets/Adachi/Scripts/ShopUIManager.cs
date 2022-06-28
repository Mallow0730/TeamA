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
    Image _itemDescriptionPanel;

    void Start()
    {
        _shopNameText.text = 0.ToString();
    }

    /// <summary>ショップメニューを表示</summary>
    public void DisplayShopMenu()
    {
        _moneyText.gameObject.SetActive(true);
        _shopNameText.gameObject.SetActive(true);
        _menuButton.ForEach(menuButton => {menuButton.gameObject.SetActive(true);});
        _displayPanel.gameObject.SetActive(true);
    }

    /// <summary>ボタンを押すと今のボタンを非表示にし、次のウィンドウを表示する</summary>
    public void NextWindow(List<Button> deleteButtons,List<Button> displayButtons)
    {
        deleteButtons.ForEach(button => { button.gameObject.SetActive(false); });//ボタンを非表示
        displayButtons.ForEach(button => { button.gameObject.SetActive(true); });//ボタンを表示
    }
}
