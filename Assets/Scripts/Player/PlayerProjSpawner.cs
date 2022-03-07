using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjSpawner : MonoBehaviour
{
    //sets varaibles related to player and its projectile
    [SerializeField] GameObject player;
    [SerializeField] GameObject projectile;
    List<GameObject> projList = new List<GameObject>();
    int numProjectile = 5;
    //position projectiles spawn in
    Vector3 spawnPos;

    private void Awake()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        //populates player's projectile list
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
            //when the player clicks their left mouse button, shoots a projectile towards where their mouse is
            foreach(GameObject proj in projList)
            {
                if(proj.activeSelf == false)
                {
                    //this help a bit with figuring out how to set direction: https://answers.unity.com/questions/736511/shoot-towards-mouse-in-unity2d.html
                    proj.GetComponent<PlayerProjBeh>().direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                    spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    proj.transform.position = spawnPos;
                    proj.SetActive(true);
                    break;
                }
            }
        }
    }
}
