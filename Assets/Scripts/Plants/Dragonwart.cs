using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonwart : PlantsTemplate
{
    [SerializeField] GameObject dragonwart;
    int curDragonHealth;

    private void Awake()
    {
        curDragonHealth = plantHealth;
    }

    private void Start()
    {
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
        if (collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curDragonHealth -= 1;
        }
    }
}
