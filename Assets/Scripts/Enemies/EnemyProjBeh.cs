using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjBeh : MonoBehaviour
{
    public float projectileVelocity = 8.0f;
    [SerializeField] GameObject enemyProjectile;
    float projectileLifetime = 0.8f;
    public Vector3 enemyProjDirection;
    Rigidbody2D rb;
    GameObject player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DeactivateProjectile(projectileLifetime));
    }

    private void FixedUpdate()
    {
        enemyProjDirection = (player.transform.position - transform.position).normalized * projectileVelocity;
        rb.velocity = new Vector2(enemyProjDirection.x, enemyProjDirection.y);
    }

    IEnumerator DeactivateProjectile(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        enemyProjectile.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            enemyProjectile.SetActive(false);
        }
    }
}
