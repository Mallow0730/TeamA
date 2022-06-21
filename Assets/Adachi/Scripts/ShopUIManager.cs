using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : SingletonMonoBehaviour<ShopUIManager>
{
    [SerializeField]
    [Header("ショップメニューのボタン")]
    List<Button> _menuButton = new List<Button>();

    [SerializeField]
    [Header("左下に表示するパネル")]
    Image _displayPanel;


    void Start()
    {
        
    }

    void Update()
    {
           
    }

    /// <summary>ショップメニューを表示</summary>
    public void DisplayShopMenu()
    {
        _menuButton.ForEach(menuButton => {menuButton.gameObject.SetActive(true);});
    }

    /// <summary>ボタンを押すと次のウィンドウを表示する</summary>
    public void NextWindow(List<Button> deleteButtons)
    {
        deleteButtons.ForEach(button => { button.gameObject.SetActive(false); });//ボタンを非表示
    }

    public void Back()
    {

    }
}
