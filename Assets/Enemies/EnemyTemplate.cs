using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTemplate : MonoBehaviour
{
    //variables that need to be public should be move to getters and setters
    public float enemyVelo = 2.0f;
    protected float enemyFireRate = 1.0f;
    public float minDistance = 15.0f;
    public float maxDistance = 20.0f;
    protected Vector3 playerPos;
    protected int curHealth;
    public bool isRanged;
    public GameObject player;

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
       // ChangeState(idleState);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //curState.UpdateState(this);
    }
}
