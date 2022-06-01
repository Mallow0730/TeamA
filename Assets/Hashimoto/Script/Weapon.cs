using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    /// <summary>武器の攻撃力</summary>
    public int Attack { get => _attack; set => _attack = value; }

    /// <summary>武器の攻撃力</summary>
    [SerializeField]
    [Header("武器の攻撃力")]
    int _attack;

}
