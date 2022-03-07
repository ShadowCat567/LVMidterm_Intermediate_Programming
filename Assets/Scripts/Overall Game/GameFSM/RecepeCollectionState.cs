using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecepeCollectionState : BaseGameState
{
    public override void EnterState(GameController manager)
    {
        //activates everything related to the Recipe Collecttion state
        manager.player.SetActive(true);
        manager.playerUI.SetActive(true);
        manager.witchHut.SetActive(true);
        manager.recepeEnemies.SetActive(true);
        manager.witchDialog.SetActive(true);
        manager.objectiveText.text = "OBJECTIVE: Collect the missing recipe fragments";
    }

    public override void UpdateState(GameController manager)
    {
        //if the player is killed, respawn them and reset the enemies
        if(manager.player.GetComponent<PlayerMovement>().playerKilled == true)
        {
            manager.player.GetComponent<PlayerMovement>().Respawn();
            manager.Reactivate();
        }
    }

    public override void ExitState(GameController manager)
    {
        
    }
}
