using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemData")]
public class ItemsData : ScriptableObject
{
    public List<ItemData> Data => _data;

    [SerializeField]
    [Header("アイテム")]
    List<ItemData> _data = new List<ItemData>();

    [Serializable]
    public class ItemData
    {
        public string Name => _name;
        public ItemType Type => _type;
        public string Explain => _explain;
        public int Rarity => _rarity;
        public int Price => _price;

        [SerializeField]
        [Tooltip("アイテムの名前")]
        string _name;

        [SerializeField]
        [Tooltip("アイテムの種類")]
        ItemType _type;

        [SerializeField]
        [Tooltip("アイテムの説明文")]
        string _explain;

        [SerializeField]
        [Tooltip("アイテムのレア度")]
        [Range(1,3)]
        int _rarity;

        [SerializeField]
        [Tooltip("値段")]
        int _price;
    }
}