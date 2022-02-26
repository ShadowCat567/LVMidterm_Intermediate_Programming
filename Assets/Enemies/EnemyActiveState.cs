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
        //if enemy is charging enemy, if the player is in range, chase the player

        //if enemy is shooting enemy, is player is in range, shoot the player
    }

    public override void ExitState(EnemyTemplate enemy)
    {

    }
}
