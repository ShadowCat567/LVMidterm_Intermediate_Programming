using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState
{
    public abstract void EnterState(GameController manager);
    public abstract void UpdateState(GameController manager);
    public abstract void ExitState(GameController manager);
}
