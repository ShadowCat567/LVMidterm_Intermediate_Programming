using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveState : EnemyBaseState
{
    public override void EnterState(EnemyTemplate enemy)
    {

    }

    public override void UpdateState(EnemyTemplate enemy)
    {
        //if the enemy is not ranged, chase the player
        if (!enemy.isRanged)
        {
            //used this to help figure out moving the enemy towards the player: https://www.codegrepper.com/code-examples/csharp/make+an+enemy+go+towards+player+unity
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.enemyVelo * Time.deltaTime);

            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) >= enemy.maxChaseDistance)
            {
                //if the player is outside of the enemy's chase range, stop chasing
                enemy.ChangeState(enemy.idleState);
            }
        }

        //if enemy is ranged, shoot projectiles at player
        else if (enemy.isRanged)
        {
            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) >= enemy.maxFireDistance)
            {
                //if player is outside of the enemy's max fire range, stop shooting
                enemy.ChangeState(enemy.idleState);
            }

            enemy.spawnTimer -= Time.deltaTime;

            //spawns projectiles and sets their direction to more towards the player
            while (enemy.spawnTimer < 0.0f)
            {
                enemy.spawnTimer += enemy.timeBetwnSpawns;

                foreach (GameObject enemyProj in enemy.enemyProjLst)
                {
                    if (enemyProj.activeSelf == false)
                    {
                        enemy.spawnPos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
                        enemyProj.transform.position = enemy.spawnPos;
                        enemyProj.GetComponent<EnemyProjBeh>().enemyProjDirection = (enemy.player.transform.position - enemy.spawnPos).normalized;
                        enemyProj.SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    public override void ExitState(EnemyTemplate enemy)
    {

    }
}
