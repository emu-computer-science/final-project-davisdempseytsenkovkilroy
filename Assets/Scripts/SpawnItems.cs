using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    //public GameObject item;
    public int xPos;
    public int yPos;
    public int itemCount;
    public GameObject GasCanPrefab;

    private void Start()
    {
        Spawn();    
    }

    void Spawn()
    {
        GameObject item;
        GameObject anchor = GameObject.Find("ItemsAnchor");
        GasCanPrefab = GameObject.Find("GasCan");
        while (itemCount < 10)
        {
            item = Instantiate<GameObject>(GasCanPrefab);
            Vector2 itemPos = Vector2.zero;
            itemPos.x = Random.Range(-9, 9);
            itemPos.y = Random.Range(-4, 4);
            item.transform.position = itemPos;
            //Instantiate(item, new Vector2(xPos, yPos), Quaternion.identity);
            item.transform.SetParent(anchor.transform);
            itemCount += 1;
        }
    }
}
