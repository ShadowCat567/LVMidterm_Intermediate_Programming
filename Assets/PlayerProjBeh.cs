using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjBeh : MonoBehaviour
{
    float velocity = 15.0f;
    [SerializeField] GameObject projectile;
    float lifetime = 1.5f;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * velocity);
        StartCoroutine(KillProjectile(lifetime));
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
