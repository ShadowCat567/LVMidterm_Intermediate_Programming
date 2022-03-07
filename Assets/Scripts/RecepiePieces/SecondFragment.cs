using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFragment : RecepiePiecesBase
{
    private void Awake()
    {
        //sets the text to be added to the player's inventory
        recepieFragmentText = "2. Intensify heat using 10 FIREBALLS";
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
