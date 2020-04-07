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
    public float itemCheckRadius = 3f;

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
            bool validPosition = false;
            //item = Instantiate<GameObject>(GasCanPrefab);
            Vector2 itemPos = Vector2.zero;
            while (!validPosition)
            {
                itemPos.x = Random.Range(itemPosMin.x, itemPosMax.x);
                itemPos.y = Random.Range(itemPosMin.y, itemPosMax.y);
                Debug.Log("itemPos.x: " + itemPos.x + "itemPos.y" + itemPos.y);

                Collider2D[] colliders = Physics2D.OverlapCircleAll(itemPos, itemCheckRadius);
                if (colliders.Length > 0)
                {
                    Debug.Log(colliders);
                    Debug.Log("not a valid position");
                    validPosition = false;
                    break;

                } else
                {
                    validPosition = true;
                    Debug.Log("valid position");
                    item = Instantiate<GameObject>(GasCanPrefab);
                    Debug.Log(itemPos);
                    item.transform.position = itemPos;
                    //Instantiate(item, new Vector2(xPos, yPos), Quaternion.identity);
                    item.transform.SetParent(anchor.transform);
                    itemCount += 1;
                    break;
                }       
            }
           
        }
    }
}
