using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    //public GameObject item;
    private int xPos;
    private int yPos;
    private int itemCount = 0;
    public int numItems;
    public GameObject GasCanPrefab;

    private void Start()
    {
        Spawn();    
    }

    void Spawn()
    {
        GameObject item;
        GameObject anchor = GameObject.Find("SpawnItems");
        //GasCanPrefab = GameObject.Find("GasCan");

        while (itemCount < numItems)
        {
            item = Instantiate<GameObject>(GasCanPrefab);
            Vector2 itemPos = Vector2.zero;
            itemPos.x = Random.Range(0, 10);
            itemPos.y = Random.Range(-5, 10);
            item.transform.position = itemPos;
            //Instantiate(item, new Vector2(xPos, yPos), Quaternion.identity);
            item.transform.SetParent(anchor.transform);
            itemCount += 1;
        }
    }
}
