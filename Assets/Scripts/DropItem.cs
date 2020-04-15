using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    [SerializeField] Text pickUpText;

    //private bool dropAllowed;
    private Transform beaver;

    private Slot slot;

    private void Awake()
    {
        pickUpText = GameObject.Find("PickUpText").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beaver")
        {
            //Debug.Log("Dam detected collision with beaver.");
            if (Beaver.isCarrying)
            {
                pickUpText.gameObject.SetActive(true);
                pickUpText.text = "Press F to destroy item.";
                //dropAllowed = true;
            }
        }
        /*
        if (collision.gameObject.tag == "Chainsaw" || collision.gameObject.tag == "GasCan")
        {
            Debug.Log("Collision with " + collision.gameObject.name);
            Scoreboard.score += 1;
            collision.gameObject.SetActive(false);
            //collision.gameObject
            float timer = 0;
            timer = timer + Time.deltaTime;
            if (timer == 2)
            {
                Destroy(collision.gameObject);
            }

        }*/

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beaver")
        {
            //Debug.Log("Beaver left Dam.");
            pickUpText.gameObject.SetActive(false);
            //dropAllowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Chainsaw" || collision.gameObject.tag == "GasCan" || collision.gameObject.tag == "Axe")
        {
            //Debug.Log("Collision with " + collision.gameObject.name);
            StartCoroutine(waitAndDestroy(collision.gameObject, 0.1f));
        }
    }

    /*
    float timer = 0f;
    timer = timer + Time.deltaTime;
        if (timer > 2f)
        {
            Debug.Log("Time is: " + timer);
            Destroy(item);
        }
        */
    IEnumerator waitAndDestroy(GameObject item, float seconds)
    {
        Scoreboard.score += 1;
        pickUpText.gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        Destroy(item);
        //Debug.Log("After Wait");
    }

/*
 * float timer = 0;
timer = timer + Time.deltaTime;
if (timer > 5)
   {

   }*/
}
