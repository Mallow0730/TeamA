using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ArmorData")]
public class ArmorsData : ScriptableObject
{
    public ArmorData[] Data => _data;

    [SerializeField]
    ArmorData[] _data;

    [Serializable]
    public class ArmorData
    {
        public int Price => _price;

        [SerializeField]
        string _armorName;

        [SerializeField]
        int _price;
    }
}