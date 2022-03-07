using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    //script all the othe drop scripts are derrived from
    //object to be dropped by another object when it is killed
    [SerializeField] protected GameObject dropObject;
    //speficies what type the object is for the player's inventory list
    public string dropType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player collides with the object, it deactivates
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            dropObject.SetActive(false);
        }
    }
}
