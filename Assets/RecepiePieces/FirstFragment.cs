using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFragment : RecepiePiecesBase
{
    private void Awake()
    {
        recepieFragmentText = "1. Boil 5 CORROSIVE FLESH in a cauldron";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            recepiePiece.SetActive(false);
        }
    }
}
