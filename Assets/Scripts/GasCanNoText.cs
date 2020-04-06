using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasCanNoText : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    Beaver player;

    public static bool isHeld = false;
    public GameObject gasCanPrefab;

    private bool pickUpAllowed;
    private Transform beaver;
    Canvas mCanvas;


    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beaver")
        {
            Debug.Log("Collision with beaver detected.");
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beaver")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(this.gameObject);
        isHeld = true;
    }
    
    public void Drop()
    {
        /*
        if (isHeld == true)
        {
            if (Beaver.IsInZone())
            {
                Scoreboard.score += 1;
                GameObject gasCan = Instantiate<GameObject>(gasCanPrefab);
                gasCan.transform.position = beaver.position;
                isHeld = false;
            }
        }
        */
        isHeld = false;

    }
    public static bool IsHeld()
    {
        return isHeld;
    }
    
}
