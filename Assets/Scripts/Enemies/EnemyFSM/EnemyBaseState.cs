using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for the enemy's finite state machine
public abstract class EnemyBaseState 
{
    public abstract void EnterState(EnemyTemplate enemy);
    public abstract void UpdateState(EnemyTemplate enemy);
    public abstract void ExitState(EnemyTemplate enemy);
}
