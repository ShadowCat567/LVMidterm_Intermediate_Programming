using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsTemplate : MonoBehaviour
{
    [SerializeField] protected GameObject droppedObject;
    protected Vector3 dropPositon;
    protected int plantHealth = 1;
    protected int numOfDrops = 2;
    protected List<GameObject> dropItemLst = new List<GameObject>();
}
