using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemyDrop : Drops
{
    private void Awake()
    {
        dropType = "Corrosive Flesh";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            dropObject.SetActive(false);
        }
    }
}
