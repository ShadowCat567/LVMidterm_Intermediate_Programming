using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlant : PlantsTemplate
{
    [SerializeField] GameObject plant;
    int curPlantHealth;

    private void Awake()
    {
        curPlantHealth = plantHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(curPlantHealth <= 0)
        {
            plant.SetActive(false);
            droppedObject.SetActive(true);
            dropPositon = transform.position;
            droppedObject.transform.position = dropPositon;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curPlantHealth -= 1;
        }
    }
}
