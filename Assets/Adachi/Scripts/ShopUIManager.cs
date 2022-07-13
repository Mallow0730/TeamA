using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShopUIManager : SingletonMonoBehaviour<ShopUIManager>
{
    [SerializeField]
    [Header("全てのボタン")]
    List<AllButton> _allButtons = new List<AllButton>();

    [SerializeField]
    [Header("所持金のテキスト")]
    Text _moneyText;

    [SerializeField]
    [Header("ショップの名前のテキスト")]
    Text _shopNameText;

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
    public void DisplayMenu(UIType uiType)
    {
        _moneyText.gameObject.SetActive(true);
        _shopNameText.gameObject.SetActive(true);
        _allButtons.Where(x => x.UiType == uiType).ToList().ForEach(x => x.SetActive(true));
        _displayPanel.gameObject.SetActive(true);
    }

    /// <summary>ボタンを押すと今のボタンを非表示にし、次のウィンドウを表示する</summary>
    public void NextMenu(List<Button> deleteButtons,List<Button> displayButtons)
    {
        deleteButtons.ForEach(button => { button.gameObject.SetActive(false); });//ボタンを非表示
        displayButtons.ForEach(button => { button.gameObject.SetActive(true); });//ボタンを表示
    }

    [System.Serializable]
    public class AllButton
    {
        public string Name => _name;
        public UIType UiType => _uiType;
        public Button Button => _button;

        [SerializeField]
        [Header("名前")]
        string _name;

        [SerializeField]
        [Header("UIの位置関係の種類")]
        UIType _uiType;

        [SerializeField]
        [Header("ボタン")]
        Button _button;

        public void SetActive(bool set)
        {
            _button.gameObject.SetActive(set);
        }
    }
}
public enum UIType
{
    Select0,
    Select1,
    Select2,
    Select3,
    Select4
}

