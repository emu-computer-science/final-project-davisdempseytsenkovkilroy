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

        //To be fixed. Destroy item from inventory.
        /*
        if (Beaver.inDropZone && Beaver.isCarrying && Input.GetKeyDown(KeyCode.F))
        {
            DropItem();
        }*/
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

    private void DisplayDropItem()
    {
            Beaver.pickUpText.gameObject.SetActive(true);
            Beaver.pickUpText.text = "Press 'G' to drop item.";
            Invoke("HidePickUpText", 1f);
    }

    private void HidePickUpText()
    {
        Beaver.pickUpText.gameObject.SetActive(false);
    }


    /*
    private void DropItem()
    {
        Debug.Log("Dropping game object: " + this.gameObject.name);
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == true)
            {
                inventory.isFull[i] = false;
                Transform player = GameObject.FindGameObjectWithTag("Beaver").gameObject.transform;
                Vector2 playerPos = new Vector2(player.position.x, player.position.y - 5);
                Instantiate(this, playerPos, Quaternion.identity); ;
                //Destroy(itemButton);
                isPickable = true;
                Beaver.isCarrying = false;
                break;
            }
        }
    }
    */
}
