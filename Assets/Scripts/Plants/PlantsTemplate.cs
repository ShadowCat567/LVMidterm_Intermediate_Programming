using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//backing class for the plant objects
public class PlantsTemplate : MonoBehaviour
{
    //object they drop upon death
    [SerializeField] protected GameObject droppedObject;
    //where the object spawns
    protected Vector3 dropPositon;
    //plant's health
    protected int plantHealth = 1;
    //variables related to drop spawning
    protected int numOfDrops = 2;
    protected List<GameObject> dropItemLst = new List<GameObject>();
}
