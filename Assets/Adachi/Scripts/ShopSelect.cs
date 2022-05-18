using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelect : MonoBehaviour
{
    /// <summary>メインカメラ</summary>
    [SerializeField]
    [Header("メインカメラ")]
    Camera _mainCamera;

    /// <summary>サブカメラ</summary>
    [SerializeField]
    [Header("サブカメラ")]
    Camera _subCamera;

    /// <summary>武器のショップ画面</summary>
    [SerializeField]
    [Header("武器のショップ画面")]
    Canvas _weaponCanvas;



    void Awake()
    {
        //_mainCamera = GetComponent<Camera>();
        //_subCamera = GetComponent<Camera>();
    }


    /// <summary>左の<のButtonを押したらカメラを切り替える</summary>
    public void LeftSelect()
    {

        _mainCamera.gameObject.SetActive(false);
        _subCamera.gameObject.SetActive(true);
    }

    /// <summary>右の>のButtonを押したらカメラを切り替える</summary>
    public void Right()
    {
        _mainCamera.gameObject.SetActive(true);
        _subCamera.gameObject.SetActive(false);
    }
}
