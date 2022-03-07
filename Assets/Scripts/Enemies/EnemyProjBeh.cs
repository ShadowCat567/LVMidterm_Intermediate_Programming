using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjBeh : MonoBehaviour
{
    //variables related to the projectile
    private float _projectileVelocity = 8.0f;
    public float projectileVelocity
    {
        get { return _projectileVelocity; }
    }

    [SerializeField] GameObject enemyProjectile;
    //how long projctile lasts before it self-destructs
    float projectileLifetime = 0.8f;
    //direction projectile moves in
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
        //destroys projectile after a set amount of time
        StartCoroutine(DeactivateProjectile(projectileLifetime));
    }

    private void FixedUpdate()
    {
        //moves projectile
        rb.velocity = enemyProjDirection * projectileVelocity;
    }

    IEnumerator DeactivateProjectile(float lifetime)
    {
        //deactiaves projectile
        yield return new WaitForSeconds(lifetime);
        enemyProjectile.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            //if the pojectile collides with the player, deactivate
            enemyProjectile.SetActive(false);
        }
    }
}
