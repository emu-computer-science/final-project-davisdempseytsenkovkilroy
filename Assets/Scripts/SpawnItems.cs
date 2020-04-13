using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    //public GameObject item;
    [Header("Set in Inpsector")]
    public Vector2 itemPosMin = new Vector2(-50, -5); 
    public Vector2 itemPosMax = new Vector2(150, 100);


    public static int goal;

    public int distanceBetweenItems;

    public int numGasCans;
    public GameObject GasCanPrefab;

    public int numAxes;
    public GameObject AxePrefab;

    public int numChainsaws;
    public GameObject ChainsawPrefab;

    public int numPlants;
    public GameObject PlantPrefab;

    public int numStumps;
    public GameObject StumpPrefab;

    public int numRocks;
    public GameObject RockPrefab;

    private List<GameObject> items;

    private void Start()
    {
        items = new List<GameObject>();
        Spawn(GasCanPrefab, numGasCans);
        Spawn(ChainsawPrefab, numChainsaws);
        Spawn(AxePrefab, numAxes);
        Spawn(RockPrefab, numRocks);
        Spawn(PlantPrefab, numPlants);
        Spawn(StumpPrefab, numStumps);
        goal = numGasCans + numChainsaws+ numAxes;
        //totalItems = numGasCans + numChainsaws + numRocks;
    }

    void Spawn(GameObject itemPrefab, int numberOfItems)
    {
        GameObject item;
        //GameObject anchor = GameObject.Find("SpawnItems");
        GameObject anchor = GameObject.FindGameObjectWithTag("InstantiateGame");
        //GasCanPrefab = GameObject.Find("GasCan");
        int counter = 0;

        while (counter < numberOfItems)
        {
            //item = Instantiate<GameObject>(itemPrefab);
            item = Instantiate<GameObject>(itemPrefab);
            Vector3 itemPos = Vector3.zero;
            itemPos.x = Random.Range(itemPosMin.x, itemPosMax.x);
            itemPos.y = Random.Range(itemPosMin.y, itemPosMax.y);
            itemPos.z = item.transform.position.z;
            foreach(GameObject o in items)
            {
                int maxTries = 100;
                Vector3 pos = o.transform.position;
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
            item.transform.SetParent(anchor.transform);
            items.Add(item);
            counter += 1;
        }
    }
}
