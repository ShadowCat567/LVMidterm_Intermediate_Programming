using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFragment : RecepiePiecesBase
{
    private void Awake()
    {
        recepieFragmentText = "3. Carefully dice 5 NIGHTLOCK and add to the cauldron.";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            recepiePiece.SetActive(false);
        }
    }
}
