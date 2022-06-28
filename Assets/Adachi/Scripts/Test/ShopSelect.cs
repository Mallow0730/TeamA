using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelect : MonoBehaviour
{
    /// <summary>武器のショップ画面</summary>
    [SerializeField]
    [Header("武器のショップ画面")]
    Canvas _weaponCanvas;

    /// <summary>装備のショップ画面</summary>
    [SerializeField]
    [Header("装備のショップ画面")]
    Canvas _armorCanvas;

    /// <summary>ショップのパネル</summary>
    [SerializeField]
    [Header("ショップのパネル")]
    Image _shopPanel = null;

    /// <summary>「＞」or「＜」Buttonを押したら切り替える</summary>
    public void Select()
    {
        if(_weaponCanvas.gameObject.activeSelf)//武器屋だったら
        {
            _weaponCanvas.gameObject.SetActive(false);
            _armorCanvas.gameObject.SetActive(true);
            _shopPanel.color = new Color32(255, 85, 0, 100);           
        }
        else//装備屋だったら
        {
            _weaponCanvas.gameObject.SetActive(true);
            _armorCanvas.gameObject.SetActive(false);
            _shopPanel.color = new Color32(41, 255, 0, 100);
        }
    }
}
