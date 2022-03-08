using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    //sets variables related to movement
    float moveSpeed = 3.0f;
    float moveX;
    float moveY;

    //sets variables related to health
    int curHealth;
    int maxHealthPlayer = 3;
    public bool playerKilled;
    //holds images that display player health
    [SerializeField] Image [] healthArr = new Image[3];
    //where player respawns after death
    [SerializeField] GameObject respwnPosition;

    //variables related to what is in the player's inventory and how many recipe pieces they have
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public List<string> recepieLst = new List<string>();
    [SerializeField] List<string> inventoryLst = new List<string>();
    bool addToInventory = false;

    //displays the player's inventory
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
        //sets up the text for the player's inventory
        InventoryPanel.SetActive(false);
        recepieCounterTxt.text = "Recipe Fragments: ( " + recepieLst.Count + "/ 5)";
        recepieItemTxt.text = "";
        inventoryText.text = "";
        //adds items to the player's inventory and sets their number to 0
        inventory.Add("Fireball", 0);
        inventory.Add("Nightshade", 0);
        inventory.Add("Corrosive Flesh", 0);
        inventory.Add("Moonstone", 0);
        inventory.Add("Dragonwort", 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        IsPlayerAlive();

        if(Input.GetKey(KeyCode.Tab))
        {
            //when tab is pressed, sorts the inventory items and displays them for the player
            //Used this to help make sure PopulateInventory() can only be called once: https://answers.unity.com/questions/155111/calling-a-function-only-once-in-update.html
            if (addToInventory == false)
            {
                addToInventory = true;
                PopulateInventory();
            }

            InventoryPanel.SetActive(true);
            //displays how many recipe fragments have been collected
            recepieCounterTxt.text = "Recipe Fragments: ( " + recepieLst.Count + " / 5 )";

            //sorts the inventory and recipe items
            Quicksort(inventoryLst, 0, inventoryLst.Count - 1);
            Quicksort(recepieLst, 0, recepieLst.Count - 1);

            //displays the inventory and recipe items
            inventoryText.text = string.Join("\n", inventoryLst);
            recepieItemTxt.text = string.Join("\n", recepieLst);
        }
        
        else
        {
            //sets inventory to inactive when tab is not being presssed
            InventoryPanel.SetActive(false);
            inventoryLst.Clear();
            addToInventory = false;
        }
    }

    private void FixedUpdate()
    {
        //moves the player
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void PlayerControls()
    { 
        //controls for the player to move
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    void IsPlayerAlive()
    {
        //if player is dead, set playerKilled to true
        if (curHealth <= 0)
        {
            playerKilled = true;
        }
    }

    public void RecipeRespawn()
    {
        //reset variables for the player to be respawned during the recipe collection state
        recepieLst.Clear();
        curHealth = maxHealthPlayer;
        ResetHearts();
        playerKilled = false;
        transform.position = respwnPosition.transform.position;
    }

    public void InvenRespawn()
    {
        //reset variables for the player to be respawned during the item collection state
        inventory["Fireball"] = 0;
        inventory["Nightshade"] = 0;
        inventory["Corrosive Flesh"] = 0;
        inventory["Moonstone"] = 0;
        inventory["Dragonwort"] = 0;
        curHealth = maxHealthPlayer;
        ResetHearts();
        playerKilled = false;
        transform.position = respwnPosition.transform.position;
    }

    void ResetHearts()
    {
        //resets the display for player health
        for(int i = 0; i < healthArr.Length; i ++)
        {
            healthArr[i].enabled = true;
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

    void PopulateInventory()
    {
        //converts the inventory dictionary to a list to make displaying and sorting it easier
        foreach (KeyValuePair<string, int> item in inventory)
        {
            inventoryLst.Add(item.Key + " : " + item.Value);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player collides with the charging enemy or the enemy's projectile, lose health and disable one of the health images
        if(collision.gameObject.GetComponent<ChargingEnemy>() || collision.gameObject.GetComponent<EnemyProjBeh>())
        {
            curHealth -= 1;
            healthArr[curHealth].enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collides with a drop, add it to player's inventory
        if(collision.gameObject.GetComponent<Drops>())
        {
            string drop = collision.gameObject.GetComponent<Drops>().dropType;
            inventory[drop] += 1;
        }

        //if player collides with recipe item, add to inventory
        if(collision.gameObject.GetComponent<RecepiePiecesBase>())
        {
            recepieLst.Add(collision.gameObject.GetComponent<RecepiePiecesBase>().recepieFragmentText);
        }
    }
}
