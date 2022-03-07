using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionState : BaseGameState
{
    public override void EnterState(GameController manager)
    {
        manager.itemCollectionSpawners.SetActive(true);
        manager.objectiveText.text = "OBJECTIVE: Collect the ingredients specified in the recipe";
    }

    public override void UpdateState(GameController manager)
    {

    }

    public override void ExitState(GameController manager)
    {
        manager.player.SetActive(false);
        manager.playerUI.SetActive(false);
        manager.witchHut.SetActive(false);
        manager.recepeEnemies.SetActive(false);
        manager.itemCollectionSpawners.SetActive(false);
        manager.objectiveText.text = "";
    }
}
