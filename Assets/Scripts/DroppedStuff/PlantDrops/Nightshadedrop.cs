using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this along with the other drops are derrived from the "Drops" script, are all stuff that is dropped upon the death of another object
public class Nightshadedrop : Drops
{
    private void Awake()
    {
        //sets the type of drop
        dropType = "Nightshade";
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
