using UnityEngine;
public class Enemy : EnemyBase,IDamage
{
    public int Damage => _damage;

    [SerializeField]
    int _damage;
    
    public void GetDamage(int d)
    {
        this._damage = d;
        EnemySlider.value -= Damage;
        print("<color=green>Playerから</color>" + Damage + "ダメージうけました");
    }
}