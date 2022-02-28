using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyTemplate enemy)
    {

    }

    public override void UpdateState(EnemyTemplate enemy)
    {
        if(enemy.isRanged)
        {
            enemy.GetComponent<EnemyProjSpawner>().enabled = false;
        }

        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.minDistance)
        {
            enemy.ChangeState(enemy.activeState);
        }
    }

    public override void ExitState(EnemyTemplate enemy)
    {

    }
}
