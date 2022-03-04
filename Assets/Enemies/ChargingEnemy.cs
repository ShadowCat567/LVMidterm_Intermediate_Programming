using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : EnemyTemplate
{
    int maxHealthCharging = 2;
    [SerializeField] GameObject droppedItem;
    Vector3 droppedPos;
    GameObject spawnDrop;

    private void Awake()
    {
        player = GameObject.Find("Player");
        curHealth = maxHealthCharging;
        isRanged = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnDrop = Instantiate(droppedItem, enemy.transform.position, Quaternion.identity);
        spawnDrop.SetActive(false);

        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        curState.UpdateState(this);

        if (curHealth <= 0)
        {
            enemy.SetActive(false);
            spawnDrop.SetActive(true);
            droppedPos = enemy.transform.position;
            spawnDrop.transform.position = droppedPos;
            curHealth = maxHealthCharging;
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
