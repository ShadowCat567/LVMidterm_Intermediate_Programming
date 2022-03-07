using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightshadedrop : Drops
{
    private void Awake()
    {
        dropType = "Nightshade";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            dropObject.SetActive(false);
        }
    }
}
