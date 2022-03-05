using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonwart : PlantsTemplate
{
    [SerializeField] GameObject dragonwart;
    int curDragonHealth;
    GameObject spawnDRdrop;

    private void Awake()
    {
        curDragonHealth = plantHealth;
    }

    private void Start()
    {
        spawnDRdrop = Instantiate(droppedObject, transform.position, Quaternion.identity);
        spawnDRdrop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (curDragonHealth <= 0)
        {
            dragonwart.SetActive(false);
            spawnDRdrop.SetActive(true);
            dropPositon = transform.position;
            spawnDRdrop.transform.position = dropPositon;
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
