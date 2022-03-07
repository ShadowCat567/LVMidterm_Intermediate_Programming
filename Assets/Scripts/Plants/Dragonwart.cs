using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonwart : PlantsTemplate
{
    //sets drop object
    [SerializeField] GameObject dragonwart;
    int curDragonHealth;

    private void Awake()
    {
        //sets current health
        curDragonHealth = plantHealth;
    }

    private void Start()
    {
        //spawns the drop objects and deactivates them to be used later
        for (int i = 0; i < numOfDrops; i++)
        {
            GameObject newDrop = Instantiate(droppedObject, transform.position, Quaternion.identity);
            newDrop.SetActive(false);
            dropItemLst.Add(newDrop);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the plant is dead, spawn a drop object in the spot it died and resets plant's health
        if (curDragonHealth <= 0)
        {
            dragonwart.SetActive(false);

            foreach (GameObject dropItem in dropItemLst)
            {
                if (dropItem.activeSelf == false)
                {
                    dropItem.SetActive(true);
                    dropPositon = transform.position;
                    dropItem.transform.position = dropPositon;
                    break;
                }
            }

            curDragonHealth = plantHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when hit by the player's projectiles, the plant loses health
        if (collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curDragonHealth -= 1;
        }
    }
}
