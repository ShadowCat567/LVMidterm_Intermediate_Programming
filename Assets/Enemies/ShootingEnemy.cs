using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyTemplate
{
    int maxHealthShooting = 1;
    //[SerializeField] GameObject droppedItem;

    private void Awake()
    {
        curHealth = maxHealthShooting;
        isRanged = true;
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
