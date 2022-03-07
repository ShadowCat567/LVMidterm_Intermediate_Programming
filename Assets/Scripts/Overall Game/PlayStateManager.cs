using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStateManager : MonoBehaviour
{
    [SerializeField] GameController manager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().recepieLst.Count == 5)
            {
                manager.ChangeState(manager.itemCollState);
            }
            
            if(collision.gameObject.GetComponent<PlayerMovement>().inventory["Fireball"] >= 6 && collision.gameObject.GetComponent<PlayerMovement>().inventory["Corrosive Flesh"] >= 5 &&
                  collision.gameObject.GetComponent<PlayerMovement>().inventory["Moonstone"] >= 4 && collision.gameObject.GetComponent<PlayerMovement>().inventory["Dragonwort"] >= 3 &&
                      collision.gameObject.GetComponent<PlayerMovement>().inventory["Nightshade"] >= 2)
            {
                //this causes an excpetion when you run into the hut and you have not collected at least 1 of each item
                manager.ChangeState(manager.endState);
            }
        }
    }
}
