using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShopUIManager : SingletonMonoBehaviour<ShopUIManager>
{
    [SerializeField]
    [Header("テキストが流れるスピード")]
    [Range(0f,1f)]
    float _speed = 0.03f;

    [SerializeField]
    [Header("全てのUI")]
    List<AllUI> _allUI = new List<AllUI>();

    [SerializeField]
    [Header("アイテム名のテキスト")]
    Text _itemNameText;

    [SerializeField]
    [Header("アイテム説明のテキスト")]
    Text _itemExplainText;

    [SerializeField]
    [Header("アイテムのレア度のテキスト")]
    Text _itemRarityText;

    [SerializeField]
    [Header("所持金のテキスト")]
    Text _moneyText;

    [SerializeField]
    [Header("ブースの名前のテキスト")]
    Text _boothNameText;

    [SerializeField]
    [Header("左下の説明テキスト")]
    Text _explainText;

    [SerializeField]
    [Header("左下の説明パネル")]
    Image _explainPanel;

    [SerializeField]
    [Header("アイテム説明のパネル")]
    Image _itemDescriptionPanel;

    [SerializeField]
    [Header("買えるアイテム")]
    ItemsData _items;

    Stack<BoothType> _boothTypes = new Stack<BoothType>();
    const int ONE = 1;
    const string RARE = "RARE ";

    void Start() 
    {
        //_explainText.text = _allUI.First(x => x.BoothType == BoothType.Home).Message;
        _boothNameText.text = _allUI.First(x => x.BoothType == BoothType.Home).BoothName;
        _moneyText.text = 0.ToString();
        _moneyText.gameObject.SetActive(true);
        _boothTypes.Push(BoothType.Home);
        StartCoroutine(Explain(_allUI.First(x => x.BoothType == BoothType.Home).Message));
    }

    /// <summary>ショップメニューを表示</summary>
    public void NextMenu(BoothType boothType)
    {
        //次のUIを表示する
        _allUI.First(x => x.BoothType == boothType).SetActive(true);
        //前のUIを非表示する
        _allUI.First(x => x.BoothType == _boothTypes.Peek()).SetActive(false);
        //現在の状態(移動した後の)を保存
        _boothTypes.Push(boothType);
        //テキストを変更
        StopAllCoroutines();
        StartCoroutine(Explain(_allUI.First(x => x.BoothType == _boothTypes.Peek()).Message));
        _boothNameText.text = _allUI.First(x => x.BoothType == boothType).BoothName;
    }

    /// <summary>戻る</summary>
    public void BackMenu()
    {
        //今のUIを非表示する
        _allUI.First(x => x.BoothType == _boothTypes.Peek()).SetActive(false);
        if (_boothTypes.Peek() == BoothType.ShopBuy) _itemDescriptionPanel.gameObject.SetActive(false);
        //今のUIの要素も消す
        if(_boothTypes.Peek() != BoothType.Home)_boothTypes.Pop();
        //古いUIを表示
        _allUI.First(x => x.BoothType == _boothTypes.Peek()).SetActive(true);
        //テキストを変更
        StopAllCoroutines();
        StartCoroutine(Explain(_allUI.First(x => x.BoothType == _boothTypes.Peek()).Message));
        _boothNameText.text = _allUI.First(x => x.BoothType == _boothTypes.Peek()).BoothName;
    }

    public void ShopItemExplain(ItemType type)
    {
        _itemDescriptionPanel.gameObject.SetActive(true);
        _itemNameText.text = _items.Data.First(x => x.Type == type).Name;
        _itemExplainText.text = _items.Data.First(x => x.Type == type).Explain;
        _itemRarityText.text = RARE + _items.Data.First(x => x.Type == type).Rarity.ToString();
    }

    public void ShopBuy()
    {
       //  = _items.Data[0].Price.ToString();
    }

    IEnumerator Explain(string text)
    {
        _explainText.text = "";
        for(var t = 0; t < text.Length; t++)
        {
            _explainText.text += _allUI.First(x => x.BoothType == _boothTypes.Peek()).Message[t];
            yield return new WaitForSeconds(_speed);
        }
    }


    [System.Serializable]
    public class AllUI
    {
        public BoothType BoothType => _boothType;
        public string BoothName => _boothName;
        public string Message => _message;
        public GameObject UI => _ui;

        [SerializeField]
        [Tooltip("名前")]
        string _name;

        [SerializeField]
        [Tooltip("表示したい店の名前")]
        string _boothName;

        [SerializeField]
        [Tooltip("表示したいメッセージ")]
        string _message;

        [SerializeField]
        [Tooltip("店の種類")]
        BoothType _boothType;

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

