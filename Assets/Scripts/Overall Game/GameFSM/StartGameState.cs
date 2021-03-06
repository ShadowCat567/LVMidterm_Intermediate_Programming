using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : BaseGameState
{
    public override void EnterState(GameController manager)
    {
        //activates everything related to start state
        manager.startbutton.SetActive(true);
        manager.startButtonText.text = "Start";
        manager.startText.text = "The Witch's Apprentice";
    }

    public override void UpdateState(GameController manager)
    {

    }

    public override void ExitState(GameController manager)
    {
        //deactivates everything related to start state
        manager.startbutton.SetActive(false);
        manager.startButtonText.text = "";
        manager.startText.text = "";
    }
}
