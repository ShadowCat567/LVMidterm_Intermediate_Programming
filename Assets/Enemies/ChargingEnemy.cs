using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : EnemyTemplate
{
    int maxHealthCharging = 2;
    [SerializeField] GameObject droppedItem;
    Vector3 droppedPos;


    private void Awake()
    {
        player = GameObject.Find("Player");
        curHealth = maxHealthCharging;
        isRanged = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //needs to spawn its own drop object/item that is added as its drop object/item
        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        curState.UpdateState(this);

        if (curHealth <= 0)
        {
            droppedItem.SetActive(true);
            droppedPos = enemy.transform.position;
            droppedItem.transform.position = droppedPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curHealth -= 1;
        }
    }
}
