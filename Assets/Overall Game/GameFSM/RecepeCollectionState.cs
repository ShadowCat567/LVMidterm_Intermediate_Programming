using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecepeCollectionState : BaseGameState
{
    public override void EnterState(GameController manager)
    {
        manager.player.SetActive(true);
        manager.playerUI.SetActive(true);
        manager.witchHut.SetActive(true);
        manager.recepeEnemies.SetActive(true);
        manager.objectiveText.text = "OBJECTIVE: Collect the missing recepe fragments";
    }

    public override void UpdateState(GameController manager)
    {
        
    }

    public override void ExitState(GameController manager)
    {
        
    }
}
