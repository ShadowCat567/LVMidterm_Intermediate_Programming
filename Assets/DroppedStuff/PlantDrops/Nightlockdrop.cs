using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightlockdrop : Drops
{
    private void Awake()
    {
        dropType = "Nightlock";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            dropObject.SetActive(false);
        }
    }
}
