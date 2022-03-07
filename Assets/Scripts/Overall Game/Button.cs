using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //when the start button is pressed, go to the start game state
    public void StartGame(GameController manager)
    {
        manager.ChangeState(manager.recepeCollState);
    }

    //when the exit button is pressed, exit the games
    public void ExitGame()
    {
        Application.Quit();
    }
}
