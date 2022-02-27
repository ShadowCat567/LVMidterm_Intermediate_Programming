using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveState : EnemyBaseState
{
    public override void EnterState(EnemyTemplate enemy)
    {

    }

    public override void UpdateState(EnemyTemplate enemy)
    {
        if (!enemy.isRanged)
        {
            //used this to help figure out moving the enemy towards the player: https://www.codegrepper.com/code-examples/csharp/make+an+enemy+go+towards+player+unity
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.enemyVelo * Time.deltaTime);

            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) >= enemy.maxDistance)
            {
                enemy.ChangeState(enemy.idleState);
            }
        }

        else
        {
            //fire projectile
        }
    }

    public override void ExitState(EnemyTemplate enemy)
    {

    }
}
