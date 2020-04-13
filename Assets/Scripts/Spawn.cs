using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private Transform dam;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Beaver").transform;
        dam = GameObject.FindGameObjectWithTag("DropZone").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos;
        if (Beaver.inDropZone)
        {
            playerPos = new Vector2(dam.position.x, dam.position.y);
        }
        else
        {
            playerPos = new Vector2(player.position.x, player.position.y); 
        }
        Instantiate(item, playerPos, Quaternion.identity);
        Beaver.isCarrying = false;
    }
}
