using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    protected override void Start() => base.Start();
    protected override void Update() => base.Update();
    protected override void OnTriggerEnter(Collider other) => base.OnTriggerEnter(other);
    protected override void EnemyDamege() => base.EnemyDamege();
}
