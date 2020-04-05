using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    //public GameObject item;
    [Header("Set in Inpsector")]
    public Vector2 itemPosMin = new Vector2(-50, -5); 
    public Vector2 itemPosMax = new Vector2(150, 100);
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
            itemPos.x = Random.Range(itemPosMin.x, itemPosMax.x);
            itemPos.y = Random.Range(itemPosMin.y, itemPosMax.y);
            item.transform.position = itemPos;
            //Instantiate(item, new Vector2(xPos, yPos), Quaternion.identity);
            item.transform.SetParent(anchor.transform);
            itemCount += 1;
        }
    }
}
