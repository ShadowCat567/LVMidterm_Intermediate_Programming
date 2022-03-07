using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonstone : PlantsTemplate
{
    [SerializeField] GameObject moonstone;
    int curMoonstonehealth;

    private void Awake()
    {
        curMoonstonehealth = plantHealth;
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
        if (curMoonstonehealth <= 0)
        {
            moonstone.SetActive(false);

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

            curMoonstonehealth = plantHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curMoonstonehealth -= 1;
        }
    }
}
