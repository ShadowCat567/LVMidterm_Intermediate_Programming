using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyProjectile;
    GameObject player;
    List<GameObject> enemyProjLst = new List<GameObject>();
    int numEnemyProj = 5;
    Vector3 spawnPos;
    float timeBetwnSpawns = 1.0f;
    float spawnTimer;

    private void Awake()
    {
        player = GameObject.Find("Player");
        spawnPos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numEnemyProj; i ++)
        {
            GameObject newEnemyProj = Instantiate(enemyProjectile, spawnPos, Quaternion.identity);
            newEnemyProj.SetActive(false);
            enemyProjLst.Add(newEnemyProj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        while(spawnTimer < 0.0f)
        {
            spawnTimer += timeBetwnSpawns;

            foreach(GameObject enemyProj in enemyProjLst)
            {
                if(enemyProj.activeSelf == false)
                {
                    spawnPos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
                    enemyProj.transform.position = spawnPos;
                    enemyProj.SetActive(true);
                    break;
                }
            }
        }
    }
}
