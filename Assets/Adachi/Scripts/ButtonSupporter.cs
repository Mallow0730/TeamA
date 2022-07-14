using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSupporter : MonoBehaviour
{
    [SerializeField]
    [Header("次に行きたい店の種類")]
    BoothType _boothType;

    [SerializeField]
    [Header("次に行きたいUIの位置の種類")]
    UIType _uiType;

    public void NextMenu() => ShopUIManager.Instance.NextMenu(_boothType,_uiType);

    public void BackMenu() => ShopUIManager.Instance.BackMenu();
}
