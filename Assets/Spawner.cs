using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    int numObjects = 3;
    [SerializeField] List<GameObject> ObjLst = new List<GameObject>();

    [SerializeField] float secBetwnSpawn = 8.0f;
    float spawnTimer;

    Vector3 spawnPos1;
    Vector3 spawnPos2;
    Vector3 spawnPos3;

    private void Awake()
    {
        spawnPos1 = new Vector3(transform.position.x + 1.0f, transform.position.y - 1.0f, transform.position.z);
        spawnPos2 = new Vector3(transform.position.x - 1.0f, transform.position.y - 1.0f, transform.position.z);
        spawnPos3 = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

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
        ObjLst[0].transform.position = spawnPos1;
        ObjLst[1].transform.position = spawnPos2;
        ObjLst[2].transform.position = spawnPos3;

        for(int i = 0; i < numObjects; i++)
        {
            ObjLst[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
