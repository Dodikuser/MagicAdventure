using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceAttak : MonoBehaviour, IDestroyable, IDealDamage
{
    public float Damage = 1f;
    private bool _active = true;

    private void Start()
    {
        Invoke("DestroyEvent", 0.1f);
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DestroyEvent();
    }
    public void DestroyEvent()
    {
        Destroy(gameObject);
    }

    public void Attack(IDamageable player)
    {
        if (!_active) return;       
        _active = false;
        player.TakeDamage(Damage);
    }
}
