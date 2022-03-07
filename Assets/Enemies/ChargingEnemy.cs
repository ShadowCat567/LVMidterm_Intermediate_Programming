using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : EnemyTemplate
{
    public int maxHealthCharging = 2;
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
        for (int i = 0; i < dropNum; i++)
        {
            GameObject spawnDrop = Instantiate(droppedItem, enemy.transform.position, Quaternion.identity);
            spawnDrop.SetActive(false);
            dropObjLst.Add(spawnDrop);
        }

        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        curState.UpdateState(this);

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
        if(collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curHealth -= 1;
        }
    }
}
