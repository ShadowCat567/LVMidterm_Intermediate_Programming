using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseGameState
{
    public override void EnterState(GameController manager)
    {
        //activates everything related to game over state
        manager.exitButton.SetActive(true);
        manager.exitButtonText.text = "Exit";
        manager.gameOverText.text = "You did it!";
    }

    public override void UpdateState(GameController manager)
    {

    }

    public override void ExitState(GameController manager)
    {
        //deactivates everything related to game over state
        manager.exitButton.SetActive(false);
        manager.exitButtonText.text = "";
        manager.gameOverText.text = "";
    }
}
