using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float moveSpeed = 3.0f;
    float moveX;
    float moveY;

    int curHealth;
    int maxHealthPlayer = 3;
    private bool playerKilled;
    [SerializeField] Image [] healthArr = new Image[3];

    [SerializeField] Dictionary<string, int> inventory = new Dictionary<string, int>();
    List<string> recepieLst = new List<string>();

    private void Awake()
    {
        playerKilled = false;
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

        if(playerKilled == true)
        {
            //end game
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ChargingEnemy>() || collision.gameObject.GetComponent<EnemyProjBeh>())
        {
            curHealth -= 1;
            healthArr[curHealth].enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Drops>())
        {
            if(inventory.ContainsKey(collision.gameObject.GetComponent<Drops>().dropType))
            {
                inventory[collision.gameObject.GetComponent<Drops>().dropType] += 1;
            }
            else
            {
                inventory.Add(collision.gameObject.GetComponent<Drops>().dropType, 1);
            }

            foreach(KeyValuePair<string, int> item in inventory)
            {
                Debug.Log("Key: " + item.Key + ", Value: " + item.Value);
            }
        }

        if(collision.gameObject.GetComponent<RecepiePiecesBase>())
        {
            recepieLst.Add(collision.gameObject.GetComponent<RecepiePiecesBase>().recepieFragmentText);
        }
    }
}
