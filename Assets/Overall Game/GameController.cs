using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    BaseGameState curstate;
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
    public GameObject itemCollectionSpawners;
    public TMP_Text objectiveText;
    public GameObject witchHut;
    public GameObject playerUI;

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
}
