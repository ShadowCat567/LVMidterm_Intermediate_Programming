using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonstonedrop : Drops
{
    private void Awake()
    {
        //sets the type of drop
        dropType = "Moonstone";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player collides with the object, it deactivates
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            dropObject.SetActive(false);
        }
    }
}
