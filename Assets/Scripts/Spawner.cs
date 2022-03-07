using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //varibles related to the object itself, object can be whatever is put in in the inspector
    [SerializeField] GameObject objectToSpawn;
    //how many objects should be held in the list
    int numObjects = 3;
    [SerializeField] List<GameObject> ObjLst = new List<GameObject>();

    //delay between spawns
    [SerializeField] float secBetwnSpawn = 8.0f;
    float spawnTimer;

    //positions for the first time objects are spawned via spawner
    Vector3 spawnPos1;
    Vector3 spawnPos2;
    Vector3 spawnPos3;

    private void Awake()
    {
        //sets the positionss
        spawnPos1 = new Vector3(transform.position.x + 1.0f, transform.position.y - 1.0f, transform.position.z);
        spawnPos2 = new Vector3(transform.position.x - 1.0f, transform.position.y - 1.0f, transform.position.z);
        spawnPos3 = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        //populates ObjLst with objects
        for (int i = 0; i < numObjects; i++)
        {
            GameObject newObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            newObject.SetActive(false);
            ObjLst.Add(newObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //sets the position of the objects the fist time they are spawned so a trio is spawned
        ObjLst[0].transform.position = spawnPos1;
        ObjLst[1].transform.position = spawnPos2;
        ObjLst[2].transform.position = spawnPos3;

        //activates objects
        for(int i = 0; i < numObjects; i++)
        {
            ObjLst[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawns objects after preliminary spawn, only spawns them one at a time
        if(ObjLst[0].activeSelf == false && ObjLst[1].activeSelf == false && ObjLst[2].activeSelf == false)
        {
            spawnTimer -= Time.deltaTime;

            while (spawnTimer < 0)
            {
                spawnTimer += secBetwnSpawn;

                foreach (GameObject obj in ObjLst)
                {
                    if (obj.activeSelf == false)
                    {
                        obj.transform.position = transform.position;
                        obj.SetActive(true);
                        break;
                    }
                }
            }
        }
    }
}
