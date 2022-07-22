using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ButtonSupporter : MonoBehaviour
{
    [SerializeField]
    [Header("次に行きたい店の種類(移動用)")]
    BoothType _boothType;
    
    [SerializeField]
    [Header("アイテムのタイプ(ショップのボタン用)")]
    ItemType _type;

    void Awake()
    {
        
    }

    public void NextMenu() => HomeUIManager.Instance.NextMenu(_boothType);
    public void BackMenu() => HomeUIManager.Instance.BackMenu();
    public void ShopItemExplain() => HomeUIManager.Instance.ShopItemExplain(_type);
    public void ShopBuy() => HomeUIManager.Instance.ShopBuy();
}
