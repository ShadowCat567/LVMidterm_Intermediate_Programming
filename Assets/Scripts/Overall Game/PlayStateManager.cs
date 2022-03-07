using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayStateManager : MonoBehaviour
{
    [SerializeField] GameController manager;
    [SerializeField] GameObject player;
    float minDistanceToPlayer = 4.0f;
    float maxDistanceToPlayer = 6.0f;

    string startRecipeColl1 = "It seems last night someone (or a group of someones) took my potion recipe. I need you to get it back so I can make the potion. Come back here once you've gotten the recipe back.";
    string notAllRecipe = "It seems like something's missing, keep looking.";

    string startItemColl1 = "Now that you've gotten the recipe back, I need you to find the ingredients so I can make it. The quatities of each ingredient are listed in the recipe. Come back when you've gotten all the ingredients.";

    [SerializeField] TMP_Text witchText;
    [SerializeField] GameObject witchTextBox;

    private void Start()
    {
        witchText.text = "";
        witchTextBox.SetActive(false);
    }

    private void Update()
    {
        if (manager.curstate == manager.recepeCollState && Vector3.Distance(transform.position, player.transform.position) <= minDistanceToPlayer)
        {
            if(player.GetComponent<PlayerMovement>().recepieLst.Count == 0)
            {
                witchTextBox.SetActive(true);
                witchText.text = startRecipeColl1;
            }

            else if(player.GetComponent<PlayerMovement>().recepieLst.Count > 0 && player.GetComponent<PlayerMovement>().recepieLst.Count < 5)
            {
                witchTextBox.SetActive(true);
                witchText.text = notAllRecipe;
            }
        }

        else if (manager.curstate == manager.itemCollState && Vector3.Distance(transform.position, player.transform.position) <= minDistanceToPlayer)
        {
            if(player.GetComponent<PlayerMovement>().inventory["Fireball"] == 0 && player.GetComponent<PlayerMovement>().inventory["Corrosive Flesh"] == 0 &&
                  player.GetComponent<PlayerMovement>().inventory["Moonstone"] == 0 && player.GetComponent<PlayerMovement>().inventory["Dragonwort"] == 0 &&
                      player.GetComponent<PlayerMovement>().inventory["Nightshade"] == 0)
            {
                witchTextBox.SetActive(true);
                witchText.text = startItemColl1;
            }
        }

        else if (Vector3.Distance(transform.position, player.transform.position) >= maxDistanceToPlayer)
        {
            witchText.text = "";
            witchTextBox.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().recepieLst.Count == 5 && manager.curstate == manager.recepeCollState)
            {
                manager.ChangeState(manager.itemCollState);
            }
            
            if(collision.gameObject.GetComponent<PlayerMovement>().inventory["Fireball"] >= 10 && collision.gameObject.GetComponent<PlayerMovement>().inventory["Corrosive Flesh"] >= 8 &&
                  collision.gameObject.GetComponent<PlayerMovement>().inventory["Moonstone"] >= 7 && collision.gameObject.GetComponent<PlayerMovement>().inventory["Dragonwort"] >= 6 &&
                      collision.gameObject.GetComponent<PlayerMovement>().inventory["Nightshade"] >= 5 && manager.curstate == manager.itemCollState)
            {
                manager.ChangeState(manager.endState);
            }
        }
    }
}
