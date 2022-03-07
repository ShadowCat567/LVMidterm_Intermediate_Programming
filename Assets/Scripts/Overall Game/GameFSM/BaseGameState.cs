using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//backing class for the overall game finite state machine
public abstract class BaseGameState
{
    public abstract void EnterState(GameController manager);
    public abstract void UpdateState(GameController manager);
    public abstract void ExitState(GameController manager);
}
