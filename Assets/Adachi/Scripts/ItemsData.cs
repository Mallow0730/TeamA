using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemData")]
public class ItemsData : ScriptableObject
{
    public List<ItemData> Data => _data;

    [SerializeField]
    List<ItemData> _data = new List<ItemData>();

    [Serializable]
    public class ItemData
    {
        public string ItemName => _itemName;
        public int Price => _price;

        [SerializeField]
        [Tooltip("アイテムの名前")]
        string _itemName;

        [SerializeField]
        [Tooltip("値段")]
        int _price;
    }
}