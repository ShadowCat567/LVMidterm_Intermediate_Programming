using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayStateManager : MonoBehaviour
{
    //reference to game manager
    [SerializeField] GameController manager;
    //variable having to do with how player and how far away they are
    [SerializeField] GameObject player;
    float minDistanceToPlayer = 4.0f;
    float maxDistanceToPlayer = 6.0f;

    //variables having to do with text that is displayed
    string startRecipeColl1 = "It seems last night someone (or a group of someones) took my potion recipe. I need you to get it back so I can make the potion. Come back here once you've gotten the recipe back.";
    string notAllRecipe = "It seems like something's missing, keep looking.";
    string startItemColl1 = "Now that you've gotten the recipe back, I need you to find the ingredients so I can make it. The quatities of each ingredient are listed in the recipe. Come back when you've gotten all the ingredients.";
    [SerializeField] TMP_Text witchText;
    [SerializeField] GameObject witchTextBox;

    private void Start()
    {
        //sets the text box to inactive
        witchText.text = "";
        witchTextBox.SetActive(false);
    }

    private void Update()
    {
        if (manager.curstate == manager.recepeCollState && Vector3.Distance(transform.position, player.transform.position) <= minDistanceToPlayer)
        {
            //if player is in range and the game is in the Recipe collection state, display text 
            if(player.GetComponent<PlayerMovement>().recepieLst.Count == 0)
            {
                witchTextBox.SetActive(true);
                witchText.text = startRecipeColl1;
            }

            else if(player.GetComponent<PlayerMovement>().recepieLst.Count > 0 && player.GetComponent<PlayerMovement>().recepieLst.Count < 5)
            {
                //display different text when player is in range and does not have all the recipe pieces yet
                witchTextBox.SetActive(true);
                witchText.text = notAllRecipe;
            }
        }

        else if (manager.curstate == manager.itemCollState && Vector3.Distance(transform.position, player.transform.position) <= minDistanceToPlayer)
        {
            //if player is in range and the game is in the Item collection state, display text 
            if (player.GetComponent<PlayerMovement>().inventory["Fireball"] == 0 && player.GetComponent<PlayerMovement>().inventory["Corrosive Flesh"] == 0 &&
                  player.GetComponent<PlayerMovement>().inventory["Moonstone"] == 0 && player.GetComponent<PlayerMovement>().inventory["Dragonwort"] == 0 &&
                      player.GetComponent<PlayerMovement>().inventory["Nightshade"] == 0)
            {
                witchTextBox.SetActive(true);
                witchText.text = startItemColl1;
            }
        }

        else if (Vector3.Distance(transform.position, player.transform.position) >= maxDistanceToPlayer)
        {
            //when player leaves range, hide the text
            witchText.text = "";
            witchTextBox.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //if player has collected all the recipe pieces, move on to the item collection state
            if (collision.gameObject.GetComponent<PlayerMovement>().recepieLst.Count == 5 && manager.curstate == manager.recepeCollState)
            {
                manager.ChangeState(manager.itemCollState);
            }
            
            //if player has collected all the ingredients, go to end state
            if(collision.gameObject.GetComponent<PlayerMovement>().inventory["Fireball"] >= 10 && collision.gameObject.GetComponent<PlayerMovement>().inventory["Corrosive Flesh"] >= 8 &&
                  collision.gameObject.GetComponent<PlayerMovement>().inventory["Moonstone"] >= 7 && collision.gameObject.GetComponent<PlayerMovement>().inventory["Dragonwort"] >= 6 &&
                      collision.gameObject.GetComponent<PlayerMovement>().inventory["Nightshade"] >= 5 && manager.curstate == manager.itemCollState)
            {
                manager.ChangeState(manager.endState);
            }
        }
    }
}
