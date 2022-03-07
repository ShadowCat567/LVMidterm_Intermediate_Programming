using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemyDrop : Drops
{
    private void Awake()
    {
        //sets type of drop
        dropType = "Corrosive Flesh";
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
