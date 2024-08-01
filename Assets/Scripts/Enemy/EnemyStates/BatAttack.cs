using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/BatAttatSttate")]
public class BatAttack : State
{
    public GameObject ThisObject;
    public GameObject PlayerObject;
    public Enemy Script;

    public float SpeedAttack = 2.0f;

    private Coroutine attackCoroutine;

    public override void Run()
    {
        if (attackCoroutine == null)
        {
            attackCoroutine = Script.StartCoroutine(AttackWithDelay());
        }
    }

    public override void Init(GameObject thisObject, GameObject followObject)
    {
        IsLoop = false;
        PlayerObject = followObject;
        ThisObject = thisObject;
        Script = ThisObject.GetComponent<Enemy>();
    }

    private IEnumerator AttackWithDelay()
    {
        while (Active)
        {
            SpawnProjectile();
            Script.Animator.SetTrigger("Attack");
            yield return new WaitForSeconds(1 / SpeedAttack);
        }
        attackCoroutine = null;
    }
    protected virtual void SpawnProjectile()
    {
        GameObject projectile = Enemy.Instantiate(PrefabContainer.Instance.EnemyProjectile, Script.SootPoint.position, Quaternion.identity);
        projectile.GetComponent<EnemyProjectile>().Init(PlayerObject);
    }
}
