using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float moveSpeed = 3.0f;
    float moveX;
    float moveY;

    int curHealth;
    int maxHealthPlayer = 3;
    bool playerKilled = false;
    //for displaying player health I think I want to figure out a heart containter system, so I'll research that and inventory tomorrow

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        curHealth = maxHealthPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        IsPlayerAlive();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void PlayerControls()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    void IsPlayerAlive()
    {
        if (curHealth <= 0)
        {
            playerKilled = true;
        }
    }
}
