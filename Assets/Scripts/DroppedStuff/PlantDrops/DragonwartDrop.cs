using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonwartDrop : Drops
{
    private void Awake()
    {
        //sets the type of drop
        dropType = "Dragonwort";
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
