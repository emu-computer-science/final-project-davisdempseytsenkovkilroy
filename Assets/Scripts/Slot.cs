using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Inventory>();
    }

    //Control for drop
    private void Update()
    {
        if (Input.GetKeyDown("f") && Beaver.isCarrying)
        {
            DropItem();
            Beaver.isCarrying = false;
            GameObject.FindGameObjectWithTag("Beaver").GetComponent<Beaver>().SetRunSpeed(30f);
        }

        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
