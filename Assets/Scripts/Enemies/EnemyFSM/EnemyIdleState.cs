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
        //if the enemy is not ranged and the player is in their chase distance, chase player
        if (!enemy.isRanged && Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.minChaseDistance)
        {
            enemy.ChangeState(enemy.activeState);
        }
        
        //if enemy is ranged and the player is in their fire range, shoot at player
        else if(enemy.isRanged && Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.minFireDistance)
        {
            enemy.ChangeState(enemy.activeState);
        }
    }

    public override void ExitState(EnemyTemplate enemy)
    {

    }
}
