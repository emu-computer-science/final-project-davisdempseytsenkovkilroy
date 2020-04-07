﻿using System.Collections;
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
    private float itemCount = 5f;
    public static int goal;

    public int distanceBetweenItems;

    public int numGasCans;
    public GameObject GasCanPrefab;

    public int numRocks;
    public GameObject RockPrefab;

    public int numChainsaws;
    public GameObject ChainsawPrefab;

    private List<GameObject> items;

    private void Start()
    {
        items = new List<GameObject>();
        Spawn(GasCanPrefab, numGasCans);
        Spawn(ChainsawPrefab, numChainsaws);
        Spawn(RockPrefab, numRocks);
        goal = numGasCans + numChainsaws;
        //totalItems = numGasCans + numChainsaws + numRocks;
    }

    void Spawn(GameObject itemPrefab, int numberOfItems)
    {
        GameObject item;
        GameObject anchor = GameObject.Find("SpawnItems");
        //GasCanPrefab = GameObject.Find("GasCan");
        int counter = 0;

        while (counter < numberOfItems)
        {
            item = Instantiate<GameObject>(itemPrefab);
            Vector2 itemPos = Vector2.zero;
            itemPos.x = Random.Range(itemPosMin.x, itemPosMax.x);
            itemPos.y = Random.Range(itemPosMin.y, itemPosMax.y);
            foreach(GameObject o in items)
            {
                int maxTries = 100;
                Vector2 pos = o.transform.position;
                while((itemPos - pos).magnitude < distanceBetweenItems)
                {
                    itemPos.x = Random.Range(itemPosMin.x, itemPosMax.x);
                    itemPos.y = Random.Range(itemPosMin.y, itemPosMax.y);
                    maxTries--;
                    if (maxTries == 0)
                        break;
                }
            }
            item.transform.position = itemPos;
            //Instantiate(item, new Vector2(xPos, yPos), Quaternion.identity);
            item.transform.SetParent(anchor.transform);
            items.Add(item);
            counter += 1;
        }
    }
}
