using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthFragment : RecepiePiecesBase
{
    private void Awake()
    {
        //sets the text to be added to the player's inventory
        recepieFragmentText = "4. Crush 6 DRAGONWART then add it to the cauldron";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player collides with the recipe fragment, self destruct
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            recepiePiece.SetActive(false);
        }
    }
}
