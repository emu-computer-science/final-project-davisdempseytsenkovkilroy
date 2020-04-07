using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    public bool isPickable;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Inventory>();
        isPickable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Beaver") && isPickable == false && Beaver.isCarrying == false)
        {
            //Debug.Log("PickUp available."+this.gameObject.name);
            isPickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Beaver"))
        {
           // Debug.Log("PickUp unavailable."+this.gameObject.name);
                isPickable = false;
        }
    }

    private void Update()
    {
        if(isPickable && Input.GetKeyDown(KeyCode.F))
        {
            AddItem();
        }
    }

    private void AddItem()
    {
        //Debug.Log("Adding game object: "+this.gameObject.name);
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                Destroy(gameObject);
                isPickable = false;
                Beaver.isCarrying = true;
                break;
            }
        }
    }

}
