using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : EnemyTemplate
{
    //sets its max health
    public int maxHealthCharging = 2;
    //item it drops
    [SerializeField] GameObject droppedItem;
    //position is spawns item in
    Vector3 droppedPos;

    private void Awake()
    {
        //finds player
        player = GameObject.Find("Player");
        //sets current health
        curHealth = maxHealthCharging;
        //this is not a ranged enemy
        isRanged = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //adds drops to their object pool
        for (int i = 0; i < dropNum; i++)
        {
            GameObject spawnDrop = Instantiate(droppedItem, enemy.transform.position, Quaternion.identity);
            spawnDrop.SetActive(false);
            dropObjLst.Add(spawnDrop);
        }

        //starts in idle state
        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        curState.UpdateState(this);

        //handle's enemy's death and resets it to be respawned again
        if (curHealth <= 0)
        {
            enemy.SetActive(false);

            foreach (GameObject dropItem in dropObjLst)
            {
                if (dropItem.activeSelf == false)
                {
                    dropItem.SetActive(true);
                    droppedPos = enemy.transform.position;
                    dropItem.transform.position = droppedPos;
                    break;
                }
            }

            curHealth = maxHealthCharging;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if hit by player's projectile, lose 1 hit point
        if(collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curHealth -= 1;
        }
    }
}
