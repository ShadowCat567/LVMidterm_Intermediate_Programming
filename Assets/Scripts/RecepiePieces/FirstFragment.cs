using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all of the fragments are more or less the same
public class FirstFragment : RecepiePiecesBase
{
    private void Awake()
    {
        //sets the text to be added to the player's inventory
        recepieFragmentText = "1. Boil 8 CORROSIVE FLESH in a cauldron";
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
