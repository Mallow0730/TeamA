using UnityEngine;
public class Enemy : EnemyBase,IDamage
{
    public void GetDamage(int d)
    {
        HPProperty(d);
        EnemySlider.value -= d;
        print("<color=green>Playerから</color>" + d + "ダメージうけました");
    }
}