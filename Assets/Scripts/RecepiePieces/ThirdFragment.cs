using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFragment : RecepiePiecesBase
{
    private void Awake()
    {
        //sets the text to be added to the player's inventory
        recepieFragmentText = "3. Carefully dice 5 NIGHTLOCK and add to the cauldron.";
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
