using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HomeUIManager : SingletonMonoBehaviour<HomeUIManager>
{
    [SerializeField]
    [Header("テキストが流れるスピード")]
    [Range(0f,1f)]
    float _speed = 0.03f;

    [SerializeField]
    [Header("アイテム購入時に表示されるテキストの表示時間")]
    [Range(0.1f,10f)]
    float _displaySeconds = 1f;

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
    [Header("アイテム購入確認のテキスト")]
    Text _itemIsBuyText;

    [SerializeField]
    [Header("アイテムを購入したときのテキスト")]
    Text _itemBoughtText;

    [SerializeField]
    [Header("左下の説明テキスト")]
    Text _explainText;

    [SerializeField]
    [Header("左下の説明パネル")]
    Image _explainPanel;

    [SerializeField]
    [Header("アイテム説明のパネル")]
    Image _itemExplainPanel;

    [SerializeField]
    [Header("アイテム購入のパネル")]
    Image _itemIsBuyPanel;

    [SerializeField]
    [Header("買えるアイテム")]
    ItemsData _items;

    /// <summary>一回だけ</summary>
    bool _isFirst;
    /// <summary>通った道の記録</summary>
    Stack<BoothType> _boothTypes = new Stack<BoothType>();
    /// <summary>アイテムのレア度のテキスト</summary>
    const string RARE = "RARE ";
    const string IS_BUY = "を購入しますか?";
    const string BOUGHT = "を購入しました";

    void Start() 
    {
        //左上のの名前を変更
        _boothNameText.text = _allUI.FirstOrDefault(x => x.BoothType == BoothType.Home).BoothName;
        _moneyText.text = 0.ToString();
        _moneyText.gameObject.SetActive(true);
        _boothTypes.Push(BoothType.Home);
        StartCoroutine(Explain(_allUI.FirstOrDefault(x => x.BoothType == BoothType.Home).Message));
        Mathf.Floor(0);
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
        //左下の説明テキストを変更
        StopAllCoroutines();
        StartCoroutine(Explain(_allUI.FirstOrDefault(x => x.BoothType == _boothTypes.Peek()).Message));
        //左上の名前を変更
        _boothNameText.text = _allUI.FirstOrDefault(x => x.BoothType == boothType).BoothName;
        _isFirst = true;
    }

    /// <summary>戻る</summary>
    public void BackMenu()
    {
        //今のUIを非表示する
        _allUI.First(x => x.BoothType == _boothTypes.Peek()).SetActive(false);
        if (_boothTypes.Peek() == BoothType.ShopBuy) _itemExplainPanel.gameObject.SetActive(false);
        //今のUIの要素も消す
        if(_boothTypes.Peek() != BoothType.Home)_boothTypes.Pop();
        //古いUIを表示
        _allUI.FirstOrDefault(x => x.BoothType == _boothTypes.Peek()).SetActive(true);
        //左下の説明テキストを変更
        if(_isFirst)
        {
            StopAllCoroutines();
            StartCoroutine(Explain(_allUI.FirstOrDefault(x => x.BoothType == _boothTypes.Peek()).Message));
        }
        if (_boothTypes.Peek() == BoothType.Home) _isFirst = false;
        //左上の名前を変更
        _boothNameText.text = _allUI.FirstOrDefault(x => x.BoothType == _boothTypes.Peek()).BoothName;
    }

    /// <summary>アイテム説明のUI</summary>
    public void ShopItemExplain(ItemType type)
    {　　　
        //それぞれアイテム名、説明文、レア度を変更
        _itemNameText.text = _items.Data.FirstOrDefault(x => x.Type == type).Name;
        _itemExplainText.text = _items.Data.FirstOrDefault(x => x.Type == type).Explain;
        _itemRarityText.text = RARE + _items.Data.FirstOrDefault(x => x.Type == type).Rarity.ToString();
    }

    /// <summary>アイテム説明パネルを表示非表示する</summary>
    public void ShopItemExplainSetActive(bool _active)
    {
        _itemExplainPanel.gameObject.SetActive(_active);
    }

    /// <summary>アイテムを購入するかどうか</summary>
    public void ShopItemIsBuy(ItemType type)
    {
        //購入画面ののテキストを変更
        _itemIsBuyText.text = _items.Data.FirstOrDefault(x => x.Type == type).Name + IS_BUY;
        //パネルを表示
        _itemIsBuyPanel.gameObject.SetActive(true);
    }

    /// <summary>アイテム購入用</summary>
    public IEnumerator ShopItemBought(ItemType type)
    {
        _itemIsBuyPanel.gameObject.SetActive(false);
        _itemBoughtText.text = _items.Data.FirstOrDefault(x => x.Type == type).Name + BOUGHT;
        _itemBoughtText.gameObject.SetActive(true);
        yield return new WaitForSeconds(_displaySeconds);
        _itemBoughtText.gameObject.SetActive(false);
    }

    /// <summary>テキストを1文字ずつ時間差で表示する</summary>
    IEnumerator Explain(string text)
    {
        //空にする
        _explainText.text = "";
        //一文字ずつ表示
        for(var t = 0; t < text.Length; t++)
        {
            _explainText.text += _allUI.FirstOrDefault(x => x.BoothType == _boothTypes.Peek()).Message[t];
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