using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
    private void Start()
    {
        Init();
    }
    private void FixedUpdate() { }

    public override void DestroyEvent()
    {
        Wood.CreateWood(new Vector3(transform.position.x, 1.4f, transform.position.z));
        Destroy(transform.gameObject);
    }
    public override void Init()
    {
        HP = MaxHP;
        //if (!EnemySpawner.Instance.Enemys.Contains(gameObject))
        //    EnemySpawner.Instance.Enemys.Add(gameObject);

        StatCanvasScript.Instance.CreateHpBar(this, transform, new Vector3(0f, 5, 0.57f));
    }
}
