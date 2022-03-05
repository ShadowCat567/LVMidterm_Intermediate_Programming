using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTemplate : MonoBehaviour
{
    //variables that need to be public should be move to getters and setters
    public float enemyVelo = 2.0f;
    public float minChaseDistance = 8.0f;
    public float maxChaseDistance = 10.0f;
    public float minFireDistance = 5.0f;
    public float maxFireDistance = 8.0f;
    protected Vector3 playerPos;
    public int curHealth;
    public bool isRanged;
    [System.NonSerialized] public GameObject player;

    [SerializeField] public GameObject enemy;
    [SerializeField] protected GameObject enemyProjectile;
    public List<GameObject> enemyProjLst = new List<GameObject>();
    public int numEnemyProj = 3;
    public Vector3 spawnPos;
    public float timeBetwnSpawns = 1.0f;
    public float spawnTimer;
    protected int dropNum = 2;
    protected List<GameObject> dropObjLst = new List<GameObject>();

    protected EnemyBaseState curState;
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyActiveState activeState = new EnemyActiveState();

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
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
