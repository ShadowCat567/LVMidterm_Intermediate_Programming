using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonstone : PlantsTemplate
{
    [SerializeField] GameObject moonstone;
    int curMoonstonehealth;
    GameObject spawnMSdrop;

    private void Awake()
    {
        curMoonstonehealth = plantHealth;
    }

    private void Start()
    {
        spawnMSdrop = Instantiate(droppedObject, transform.position, Quaternion.identity);
        spawnMSdrop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (curMoonstonehealth <= 0)
        {
            moonstone.SetActive(false);
            spawnMSdrop.SetActive(true);
            dropPositon = transform.position;
            spawnMSdrop.transform.position = dropPositon;
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
