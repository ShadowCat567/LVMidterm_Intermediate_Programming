using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//backing class for the enemies
public class EnemyTemplate : MonoBehaviour
{
    //backing var for the enemy's speed
    private float _enemyVelo = 2.0f;
    //no need to set enemy's velocity, only a getter
    public float enemyVelo
    {
        get { return _enemyVelo; }
    }

    //variables related to how close player needs to be to enemy for it to notice the player
    public float minChaseDistance = 8.0f;
    public float maxChaseDistance = 10.0f;
    public float minFireDistance = 5.0f;
    public float maxFireDistance = 8.0f;
    //player's position
    protected Vector3 playerPos;
    //current health
    public int curHealth;
    //tells whether or not the enemy is ranged
    public bool isRanged;
    //player, needs to be public but don't want to set in inspector
    [System.NonSerialized] public GameObject player;

    //varaibles related to projectile spawning
    [SerializeField] public GameObject enemy;
    [SerializeField] protected GameObject enemyProjectile;
    public List<GameObject> enemyProjLst = new List<GameObject>();
    //number of projectiles enemy spawns
    private int _numEnemyProj = 3;
    //time between when projectiles are shot
    private float _timeBetwnSpawns = 1.0f;

    public int numEnemyProj
    {
        get { return _numEnemyProj; }
    }
    public float timeBetwnSpawns
    {
        get { return _timeBetwnSpawns; }
    }
    //place where projectiles are spawned
    public Vector3 spawnPos;
    //related to time between spawns
    public float spawnTimer;

    //variables related to what enemy drops upon death
    //number of drops the enemy instantiates
    protected int dropNum = 2;
    protected List<GameObject> dropObjLst = new List<GameObject>();

    //variables related to enemy finite state machine
    protected EnemyBaseState curState;
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyActiveState activeState = new EnemyActiveState();

    //changes the state in the FSM
    public void ChangeState(EnemyBaseState newState)
    {
        if(curState != null)
        {
            curState.ExitState(this);
        }

        curState = newState;

        if(curState != null)
        {
            curState.EnterState(this);
        }
    }

    private void Awake()
    {
        //finds the player
        player = GameObject.Find("Player");
    }
}
