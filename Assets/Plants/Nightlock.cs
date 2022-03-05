using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightlock : PlantsTemplate
{
    [SerializeField] GameObject nightlock;
    int curnightlockhealth;
    GameObject spawnNLdrop;

    private void Awake()
    {
        curnightlockhealth = plantHealth;
    }

    private void Start()
    {
        spawnNLdrop = Instantiate(droppedObject, transform.position, Quaternion.identity);
        spawnNLdrop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (curnightlockhealth <= 0)
        {
            nightlock.SetActive(false);
            spawnNLdrop.SetActive(true);
            dropPositon = transform.position;
            spawnNLdrop.transform.position = dropPositon;
            curnightlockhealth = plantHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curnightlockhealth -= 1;
        }
    }
}
