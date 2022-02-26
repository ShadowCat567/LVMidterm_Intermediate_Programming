using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour
{
    protected float enemyVelo = 2.0f;
    protected float enemyFireRate = 1.0f;
    protected float alertRange;
    protected Vector3 playerPos;
    protected int curHealth;
    protected bool isRanged;

    EnemyBaseState curState;
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
        ChangeState(idleState);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curState.UpdateState(this);
    }
}
