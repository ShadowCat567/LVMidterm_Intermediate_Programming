using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonstonedrop : Drops
{
    private void Awake()
    {
        dropType = "Moonstone";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            dropObject.SetActive(false);
        }
    }
}
