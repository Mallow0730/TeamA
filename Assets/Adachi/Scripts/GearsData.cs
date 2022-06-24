using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GearData")]
public class GearsData : ScriptableObject
{
    public GearData[] Data => _data;

    [SerializeField]
    GearData[] _data;

    [Serializable]
    public class GearData
    {
        public int Price => _price;

        [SerializeField]
        string _GearName;

        [SerializeField]
        int _price;
    }
}