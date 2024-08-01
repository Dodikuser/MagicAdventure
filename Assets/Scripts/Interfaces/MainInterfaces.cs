using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public event Action<float> HPChange;
    public void TakeDamage(float damage);
}
public interface IDestroyable
{
    public void DestroyEvent();
}
public interface IDealDamage
{
    public void Attack(IDamageable damageable);
}
