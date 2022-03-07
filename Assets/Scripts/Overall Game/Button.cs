using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void StartGame(GameController manager)
    {
        manager.ChangeState(manager.recepeCollState);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
