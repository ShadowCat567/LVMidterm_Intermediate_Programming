using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : EnemyTemplate
{
    int maxHealthCharging = 2;
    //[SerializeField] GameObject droppedItem;

    private void Awake()
    {
        curHealth = maxHealthCharging;
        isRanged = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        curState.UpdateState(this);
    }
}
