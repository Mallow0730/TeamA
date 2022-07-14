using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShopUIManager : SingletonMonoBehaviour<ShopUIManager>
{
    public BoothType NowBoothType => _nowBoothType;
    public UIType NowUIType => _nowUIType;

    [SerializeField]
    [Header("全てのUI")]
    List<AllUI> _allUIs = new List<AllUI>();

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

    BoothType _nowBoothType = BoothType.Home;
    UIType _nowUIType = UIType.Select0;
    const int ONE = 1;

    void Start() 
    {
        _moneyText.text = 0.ToString();
        _moneyText.gameObject.SetActive(true);
        _boothNameText.gameObject.SetActive(true);
    }

    /// <summary>ショップメニューを表示</summary>
    public void NextMenu(BoothType boothType, UIType uiType)
    {       
        //次のUIを表示する
        _allUIs.Where(x => x.BoothType == boothType && x.UiType == uiType).ToList().ForEach(x => x.SetActive(true));
        //前のUIを非表示する
        _allUIs.Where(x => x.UiType == uiType - ONE).ToList().ForEach(x => x.SetActive(false));
        //現在の状態を保存
        _nowBoothType = boothType;
        _nowUIType = uiType;
    }

    /// <summary>戻る</summary>
    public void BackMenu()
    {
        //今のUIを非表示する
        _allUIs.Where(x => x.BoothType == _nowBoothType && x.UiType == _nowUIType).ToList().ForEach(x => x.SetActive(false));
        if (_nowBoothType == BoothType.ShopSell) _nowBoothType = BoothType.ShopBuy;
        //次のUIを表示
        _allUIs.Where(x => x.BoothType == _nowBoothType - ONE && x.UiType == _nowUIType - ONE).ToList().ForEach(x => x.SetActive(true));
    }

    [System.Serializable]
    public class AllUI
    {
        public BoothType BoothType => _boothType;
        public UIType UiType => _uiType;
        public GameObject UI => _ui;

        [SerializeField]
        [Tooltip("名前")]
        string _name;

        [SerializeField]
        [Tooltip("店の種類")]
        BoothType _boothType;

        [SerializeField]
        [Tooltip("UIの位置の種類")]
        UIType _uiType;

        [SerializeField]
        [Tooltip("UI")]
        GameObject _ui;

        public void SetActive(bool set)
        {
            _ui.gameObject.SetActive(set);
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

