using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyTemplate
{
    [SerializeField] GameObject droppedItem;
    GameObject spawnDrop;
    Vector3 droppedPos;
    int maxHealthShooting = 1;

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

        spawnDrop = Instantiate(droppedItem, enemy.transform.position, Quaternion.identity);
        spawnDrop.SetActive(false);

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
            spawnDrop.SetActive(true);
            droppedPos = enemy.transform.position;
            spawnDrop.transform.position = droppedPos;
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
