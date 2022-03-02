using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField] protected GameObject dropObject;
    protected string dropType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            dropObject.SetActive(false);
        }
    }
}
