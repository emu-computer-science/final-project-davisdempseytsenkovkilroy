using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    public static bool isPickable;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Beaver"))
        {
            if(inventory.slots[inventory.slots.Length-1].gameObject != null)
            {
                Beaver.isPickable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Beaver"))
        {
            if (inventory.slots[inventory.slots.Length-1] != null)
            {
                Beaver.isPickable = false;
            }
        }
    }

    private void Update()
    {
        if(Beaver.isPickable && Input.GetKeyDown(KeyCode.F))
        {
            AddItem();
        }
    }

    private void AddItem()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                Destroy(gameObject);
                Beaver.isPickable = false;
                break;
            }
        }
    }

}
