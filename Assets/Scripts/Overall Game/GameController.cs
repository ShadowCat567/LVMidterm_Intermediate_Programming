using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    //variables related to the state the game is in
    public BaseGameState curstate;
    public StartGameState startState = new StartGameState();
    public RecepeCollectionState recepeCollState = new RecepeCollectionState();
    public ItemCollectionState itemCollState = new ItemCollectionState();
    public GameOverState endState = new GameOverState();

    //variables related to the start state
    [Header("Game Start")]
    public GameObject startbutton;
    public TMP_Text startButtonText;
    public TMP_Text startText;

    //variables related to the Recipe collection and Item collection states
    [Header("Playing Game")]
    public GameObject player;
    public GameObject recepeEnemies;
    public GameObject[] recipeEnemiesArr = new GameObject[5];
    public GameObject itemCollectionSpawners;
    public TMP_Text objectiveText;
    public GameObject witchHut;
    public GameObject playerUI;
    public GameObject witchDialog;
    public GameObject barrier;

    //variables related to the end state
    [Header("Game End")]
    public GameObject exitButton;
    public TMP_Text exitButtonText;
    public TMP_Text gameOverText;

    //changes the game's state
    public void ChangeState(BaseGameState newState)
    {
        if(curstate != null)
        {
            curstate.ExitState(this);
        }

        curstate = newState;

        if(curstate != null)
        {
            curstate.EnterState(this);
        }
    }

    private void Awake()
    {
        //deactivates everything from the Recipe collection and Item collection states
        player.SetActive(false);
        recepeEnemies.SetActive(false);
        itemCollectionSpawners.SetActive(false);
        witchHut.SetActive(false);
        witchDialog.SetActive(false);
        playerUI.SetActive(false);
        barrier.SetActive(false);
        objectiveText.text = "";

        //deactivates everything in the end state
        exitButton.SetActive(false);
        exitButtonText.text = "";
        gameOverText.text = "";

        //starts in the start state
        ChangeState(startState);
    }

    // Update is called once per frame
    void Update()
    {
        curstate.UpdateState(this);
    }

    public void Reactivate()
    {
        //if the player dies in the Recipe collection state, reactivates the enemies they killed
        for(int i = 0; i < recipeEnemiesArr.Length; i ++)
        {
            if(recipeEnemiesArr[i].activeSelf == false)
            {
                if(recipeEnemiesArr[i].GetComponent<EnemyTemplate>().isRanged)
                {
                    recipeEnemiesArr[i].GetComponent<ShootingEnemy>().curHealth = recipeEnemiesArr[i].GetComponent<ShootingEnemy>().maxHealthShooting;
                }
                else
                {
                    recipeEnemiesArr[i].GetComponent<ChargingEnemy>().curHealth = recipeEnemiesArr[i].GetComponent<ChargingEnemy>().maxHealthCharging;
                }

                recipeEnemiesArr[i].SetActive(true);
            }
        }
    }
}
