using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    [SerializeField] GameObject InventoryPanel;
    [SerializeField] TMP_Text recepieCounterTxt;
    [SerializeField] TMP_Text recepieItemTxt;
    [SerializeField] TMP_Text inventoryText;

    private void Awake()
    {
        playerKilled = false;
        rb = GetComponent<Rigidbody2D>();
        curHealth = maxHealthPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.SetActive(false);
        recepieCounterTxt.text = "Recepie Fragments: ( " + recepieLst.Count + "/ 5)";
        recepieItemTxt.text = "";
        inventoryText.text = "";
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

        if(Input.GetKey(KeyCode.Tab))
        {
            InventoryPanel.SetActive(true);
            recepieCounterTxt.text = "Recepie Fragments: ( " + recepieLst.Count + "/ 5)";

            Quicksort(recepieLst, 0, recepieLst.Count - 1);

            recepieItemTxt.text = string.Join("\n", recepieLst);
            
            foreach (KeyValuePair<string, int> item in inventory)
            {
                inventoryText.text = item.Key + " : " + item.Value + "\n";
            }
            //sort dictionary and recepie list 
            //display updated recepie and inventory 
        }
        
        else
        {
            InventoryPanel.SetActive(false);
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

    //Used this to help figure out quicksort: https://www.geeksforgeeks.org/quick-sort/
    void Quicksort(List<string> lst, int low, int high)
    {
        //while low is less than high, run quicksort
        if (low < high)
        {
            //puts the partitioning index in the right place, in this case, puts the last element in the list in the right place
            int part = Partition(lst, low, high);
            //uses recursion to split the list based on the index returned by the partition function
            //moves through list with recursion until there are no more values that need to be sorted
            //first call deals with the part of the list before the partition value's index
            Quicksort(lst, low, part - 1);
            //second call deals with the part of the list after the partition value's index
            Quicksort(lst, part + 1, high);
        }
    }

    int Partition(List<string> lst, int low, int high)
    {
        //when given a pivot point, put all the values less than it in front of it and all values greater after
        //pivot is value to be sorted
        string pivot = lst[high];
        //indicates right most position of pivot
        int i = (low - 1);
        for( int j = low; j <= (high - 1); j ++)
        {
            if(string.Compare(lst[j], pivot) < 0)
            {
                //if the value of j is less than the pivot, increase i and replace the value of j with the value of i 
                i++;
                string temp = lst[i];
                lst[i] = lst[j];
                lst[j] = temp;
            }
        }
        //move the pivot value to its correct position
        string temp1 = lst[i + 1];
        lst[i + 1] = lst[high];
        lst[high] = temp1;

        return (i + 1);
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
