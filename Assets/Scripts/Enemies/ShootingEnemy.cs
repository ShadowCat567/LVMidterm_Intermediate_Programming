using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyTemplate
{
    [SerializeField] GameObject droppedItem;
    Vector3 droppedPos;
    public int maxHealthShooting = 1;

    private void Awake()
    {
        player = GameObject.Find("Player");
        curHealth = maxHealthShooting;
        isRanged = true;
        spawnPos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(idleState);

        for (int j = 0; j < dropNum; j++)
        {
            GameObject spawnDrop = Instantiate(droppedItem, enemy.transform.position, Quaternion.identity);
            spawnDrop.SetActive(false);
            dropObjLst.Add(spawnDrop);
        }

        for (int i = 0; i < numEnemyProj; i++)
        {
            GameObject newEnemyProj = Instantiate(enemyProjectile, spawnPos, Quaternion.identity);
            newEnemyProj.SetActive(false);
            enemyProjLst.Add(newEnemyProj);
        }
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
            
            curHealth = maxHealthShooting;
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
