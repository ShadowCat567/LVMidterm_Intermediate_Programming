using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
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

    //variables related to the play state
    [Header("Playing Game")]
    public GameObject player;
    public GameObject recepeEnemies;
    public GameObject[] recipeEnemiesArr = new GameObject[5];
    public GameObject itemCollectionSpawners;
    public TMP_Text objectiveText;
    public GameObject witchHut;
    public GameObject playerUI;
    public GameObject witchDialog;

    //variables related to the end state
    [Header("Game End")]
    public GameObject exitButton;
    public TMP_Text exitButtonText;
    public TMP_Text gameOverText;

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
        player.SetActive(false);
        recepeEnemies.SetActive(false);
        itemCollectionSpawners.SetActive(false);
        witchHut.SetActive(false);
        witchDialog.SetActive(false);
        playerUI.SetActive(false);
        objectiveText.text = "";

        exitButton.SetActive(false);
        exitButtonText.text = "";
        gameOverText.text = "";

        ChangeState(startState);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curstate.UpdateState(this);
    }

    public void Reactivate()
    {
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
