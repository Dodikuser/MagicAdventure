using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected float SpeedAttack;
    public bool Active = true;

    public virtual IEnumerator Fire() { yield break; }
    public virtual void StartAttack() { }
}
