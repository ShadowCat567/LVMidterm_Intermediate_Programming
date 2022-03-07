using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthFragment : RecepiePiecesBase
{
    private void Awake()
    {
        recepieFragmentText = "4. Crush 3 DRAGONWART then add it to the cauldron";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            recepiePiece.SetActive(false);
        }
    }
}
