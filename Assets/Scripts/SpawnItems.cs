using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject item;
    public int xPos;
    public int yPos;
    public int itemCount;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        while (itemCount < 10)
        {
            xPos = Random.Range(-5, 5);
            yPos = Random.Range(-5, 5);
            Instantiate(item, new Vector2(xPos, yPos), Quaternion.identity);
            itemCount += 1;
        }
    }
}
