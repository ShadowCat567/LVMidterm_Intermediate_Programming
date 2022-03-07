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
        if (!enemy.isRanged)
        {
            //used this to help figure out moving the enemy towards the player: https://www.codegrepper.com/code-examples/csharp/make+an+enemy+go+towards+player+unity
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.enemyVelo * Time.deltaTime);

            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) >= enemy.maxChaseDistance)
            {
                enemy.ChangeState(enemy.idleState);
            }
        }

        else if (enemy.isRanged)
        {
            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) >= enemy.maxFireDistance)
            {
                enemy.ChangeState(enemy.idleState);
            }

            enemy.spawnTimer -= Time.deltaTime;

            while (enemy.spawnTimer < 0.0f)
            {
                enemy.spawnTimer += enemy.timeBetwnSpawns;

                foreach (GameObject enemyProj in enemy.enemyProjLst)
                {
                    if (enemyProj.activeSelf == false)
                    {
                        enemy.spawnPos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
                        enemyProj.transform.position = enemy.spawnPos;
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
