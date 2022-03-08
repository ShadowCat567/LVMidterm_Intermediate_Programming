using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionState : BaseGameState
{
    public override void EnterState(GameController manager)
    {
        //activates everything related to Item collection that isn't already active
        manager.itemCollectionSpawners.SetActive(true);
        //changes objective text
        manager.objectiveText.text = "OBJECTIVE: Collect the ingredients specified in the recipe";
    }

    public override void UpdateState(GameController manager)
    {
        //if the player is killed, respawn them, not nessicary to reset enemies
        if (manager.player.GetComponent<PlayerMovement>().playerKilled == true)
        {
            manager.player.GetComponent<PlayerMovement>().InvenRespawn();
        }
    }

    public override void ExitState(GameController manager)
    {
        //deactivates everything related to the Item collection and recipe collectcion states
        manager.player.SetActive(false);
        manager.playerUI.SetActive(false);
        manager.witchHut.SetActive(false);
        manager.recepeEnemies.SetActive(false);
        manager.itemCollectionSpawners.SetActive(false);
        manager.witchDialog.SetActive(false);
        manager.barrier.SetActive(false);
        manager.objectiveText.text = "";
    }
}
