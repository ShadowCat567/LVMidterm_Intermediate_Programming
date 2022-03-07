using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    //sets an offset to follow the player by
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //sets the offset's value
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //camera's position changes based off player's pos and offset
        transform.position = player.transform.position + offset;
    }
}
