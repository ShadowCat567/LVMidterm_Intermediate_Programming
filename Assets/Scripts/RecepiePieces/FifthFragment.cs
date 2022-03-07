using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthFragment : RecepiePiecesBase
{
    private void Awake()
    {
        //sets the text to be added to the player's inventory
        recepieFragmentText = "5. Finally, crush 7 MOONSTONE and sprinkle it into the mixture as it cools.";
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
