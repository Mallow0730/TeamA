using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ButtonSupporter : MonoBehaviour
{
    [SerializeField]
    [Header("次に行きたい店の種類")]
    BoothType _boothType;

    public void NextMenu() => ShopUIManager.Instance.NextMenu(_boothType);
    public void BackMenu() => ShopUIManager.Instance.BackMenu();
    public void ShopBuy(Text text) => ShopUIManager.Instance.ShopBuy(text);
}
