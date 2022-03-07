using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFragment : RecepiePiecesBase
{
    private void Awake()
    {
        recepieFragmentText = "2. Intensify heat using 10 FIREBALLS";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            recepiePiece.SetActive(false);
        }
    }
}
