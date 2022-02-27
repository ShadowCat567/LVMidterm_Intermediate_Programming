using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerBc;
    [SerializeField] GameObject player;
    [SerializeField] GameObject projectile;
    List<GameObject> projList = new List<GameObject>();
    int numProjectile = 15;
    Vector3 spawnPos;

    private void Awake()
    {
        playerBc = GetComponent<BoxCollider2D>();
        spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numProjectile; i ++)
        {
            GameObject newProjectile = Instantiate(projectile, spawnPos, Quaternion.identity);
            newProjectile.SetActive(false);
            projList.Add(newProjectile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            foreach(GameObject proj in projList)
            {
                if(proj.activeSelf == false)
                {   //change this so it shoots in the direction of the mouse
                    if (Input.GetKey(KeyCode.A))
                    {
                        proj.gameObject.GetComponent<PlayerProjBeh>().direction = Vector3.left;
                        spawnPos = new Vector3(transform.position.x - (playerBc.size.x / 2), transform.position.y, transform.position.z);
                    }

                    else if (Input.GetKey(KeyCode.D))
                    {
                        proj.gameObject.GetComponent<PlayerProjBeh>().direction = Vector3.right;
                        spawnPos = new Vector3(transform.position.x + (playerBc.size.x / 2), transform.position.y, transform.position.z);
                    }

                    else if (Input.GetKey(KeyCode.W))
                    {
                        proj.gameObject.GetComponent<PlayerProjBeh>().direction = Vector3.up;
                        spawnPos = new Vector3(transform.position.x, transform.position.y + (playerBc.size.y /2), transform.position.z);
                    }

                    else if (Input.GetKey(KeyCode.S))
                    {
                        proj.gameObject.GetComponent<PlayerProjBeh>().direction = Vector3.down;
                        spawnPos = new Vector3(transform.position.x, transform.position.y - (playerBc.size.y / 2), transform.position.z);
                    }

                    proj.transform.position = spawnPos;
                    proj.SetActive(true);
                    break;
                }
            }
        }
    }
}
