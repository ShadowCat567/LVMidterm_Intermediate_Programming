using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjBeh : MonoBehaviour
{
    //sets varaibles related to projectile
    float velocity = 30.0f;
    [SerializeField] GameObject projectile;
    //how long projectile lives before self destructing
    float lifetime = 0.5f;
    public Vector2 direction;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(KillProjectile(lifetime));
    }

    private void LateUpdate()
    {
        //moves the projectile
        rb.velocity = direction * velocity;
    }

    IEnumerator KillProjectile(float projLifetime)
    {
        //kills the projectile after its lifetime is complete
        yield return new WaitForSeconds(projLifetime);
        projectile.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the projectile collides with one of the enemies, self destruct
        if(collision.gameObject.GetComponent<ChargingEnemy>() || collision.gameObject.GetComponent<ShootingEnemy>())
        {
            projectile.SetActive(false);
        }
    }
}
