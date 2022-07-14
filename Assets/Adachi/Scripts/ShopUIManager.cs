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
    [Header("ブースの名前のテキスト")]
    Text _boothNameText;

    [SerializeField]
    [Header("左下の説明パネル")]
    Image _explainPanel;

    [SerializeField]
    [Header("アイテム説明のパネル")]
    Image _itemDescriptionPanel;

    void Start()
    {
        _moneyText.text = 0.ToString();
        _moneyText.gameObject.SetActive(true);
        _boothNameText.gameObject.SetActive(true);
    }

    /// <summary>ショップメニューを表示</summary>
    public void NextMenu(BoothType boothType, UIType uiType)
    {           
        _allButtons.Where(x => x.BoothType == boothType && x.UiType == uiType).ToList().ForEach(x => x.SetActive(true));
        _allButtons.Where(x => x.UiType == uiType--).ToList().ForEach(x => x.SetActive(false));
    }

    /// <summary>戻る</summary>
    public void BackMenu(BoothType boothType, UIType uiType)
    {      
        _allButtons.Where(x => x.BoothType == boothType && x.UiType == uiType).ToList().ForEach(x => x.SetActive(true));
        _allButtons.Where(x => x.UiType == uiType++).ToList().ForEach(x => x.SetActive(false));
    }

    [System.Serializable]
    public class AllButton
    {
        public BoothType BoothType => _boothType;
        public UIType UiType => _uiType;
        public Button Button => _button;

        [SerializeField]
        [Header("名前")]
        string _name;

        [SerializeField]
        [Header("店の種類")]
        BoothType _boothType;

        [SerializeField]
        [Header("UIの位置の種類")]
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
public enum BoothType
{
    Home,
    ShopSelect,
    ShopBuy,
    ShopSell
}
public enum UIType
{
    Select0,
    Select1,
    Select2,
    Select3,
    Select4
}

