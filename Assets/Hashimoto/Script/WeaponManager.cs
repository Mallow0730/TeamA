using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager:SingletonMonoBehaviour<WeaponManager>
{ 
    public List<AllAttack> AllAttacks => _allAttacks;

    [SerializeField]
    List<AllAttack> _allAttacks = new List<AllAttack>();

    [System.Serializable]
    public class AllAttack
    {
        /// <summary>武器の名前</summary>
        public string WeaponName => _name;

        /// <summary>武器の攻撃力</summary>
        public int Attack => _attack;

        [SerializeField]
        [Header("武器の名前")]
        string _name;

        [SerializeField]
        [Header("攻撃力")]
        int _attack;
    }
}
