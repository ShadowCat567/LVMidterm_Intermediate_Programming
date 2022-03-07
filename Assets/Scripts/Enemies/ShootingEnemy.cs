using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//derrived from the EnemyTemplate
public class ShootingEnemy : EnemyTemplate
{
    //item it drops when it dies
    [SerializeField] GameObject droppedItem;
    //position the item will be dropped
    Vector3 droppedPos;
    //backing variable for enemy's max health
    private int _maxHealthShooting = 1;
    public int maxHealthShooting
    {
        get { return _maxHealthShooting; }
    }

    private void Awake()
    {
        //find the platers
        player = GameObject.Find("Player");
        curHealth = maxHealthShooting;
        //is a ranged enemy
        isRanged = true;
        //position projectiles should be spawned from
        spawnPos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        //starts in idle state
        ChangeState(idleState);

        //instantiates drop objects associated with this enemy and adds them to list
        for (int j = 0; j < dropNum; j++)
        {
            GameObject spawnDrop = Instantiate(droppedItem, enemy.transform.position, Quaternion.identity);
            spawnDrop.SetActive(false);
            dropObjLst.Add(spawnDrop);
        }

        //instantiates projectiles to be shot later
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

        //if the enemy is dead, this is not in the FSM since there are some stuff specific to this enemy that needs to happen
        if (curHealth <= 0)
        {
            enemy.SetActive(false);

            foreach (GameObject dropItem in dropObjLst)
            {
                //activate the first item is finds in the drop list at the position the enemy died in
                if (dropItem.activeSelf == false)
                {
                    dropItem.SetActive(true);
                    droppedPos = enemy.transform.position;
                    dropItem.transform.position = droppedPos;
                    break;
                }
            }
            
            //resets health
            curHealth = maxHealthShooting;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player's projectile hits it, lose one health
        if(collision.gameObject.GetComponent<PlayerProjBeh>())
        {
            curHealth -= 1;
        }
    }
}
