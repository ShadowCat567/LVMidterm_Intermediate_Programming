using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState 
{
    public abstract void EnterState(EnemyTemplate enemy);
    public abstract void UpdateState(EnemyTemplate enemy);
    public abstract void ExitState(EnemyTemplate enemy);
}
