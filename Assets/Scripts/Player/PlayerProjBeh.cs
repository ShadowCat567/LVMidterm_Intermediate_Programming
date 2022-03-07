using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjBeh : MonoBehaviour
{
    float velocity = 30.0f;
    [SerializeField] GameObject projectile;
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
        rb.velocity = direction * velocity;
    }

    IEnumerator KillProjectile(float projLifetime)
    {
        yield return new WaitForSeconds(projLifetime);
        projectile.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ChargingEnemy>() || collision.gameObject.GetComponent<ShootingEnemy>())
        {
            projectile.SetActive(false);
        }
    }
}
