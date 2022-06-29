using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager:SingletonMonoBehaviour<WeaponManager>
{ 
    /// <summary>武器の攻撃力</summary>
    public int Attack => _attack;

    /// <summary>武器の攻撃力</summary>
    [Header("武器の攻撃力")]
    int _attack;

    public int WeaponAttack(int attack) => _attack = attack;
}
