using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/SkeletonAttakSttate")]
public class SkeletonAttack : State
{
    public GameObject ThisObject;
    public GameObject PlayerObject;
    public Enemy Script;
    

    public float SpeedAttack = 2.0f;

    public override void Run()
    {
        if (Script.attackCoroutine == null)
        {
            Script.attackCoroutine = Script.StartCoroutine(AttackWithDelay());
        }
    }

    private IEnumerator AttackWithDelay()
    {
        while (Active)
        {
            Script.Animator.SetTrigger("Attack");
            yield return new WaitForSeconds(1);
            SpawnSlice();
            yield return new WaitForSeconds(1 / SpeedAttack);
        }
        Script.attackCoroutine = null;
    }
    protected virtual void SpawnSlice()
    {
        GameObject slice = Enemy.Instantiate(PrefabContainer.Instance.SkeletonMaleAttak, Script.SootPoint.position, ThisObject.transform.rotation);
        //slice.GetComponent<EnemyProjectile>().Init(PlayerObject);
    }
    public override void Init(GameObject thisObject, GameObject followObject)
    {
        IsLoop = false;
        PlayerObject = followObject;
        ThisObject = thisObject;
        Script = ThisObject.GetComponent<Enemy>();
    }
}
