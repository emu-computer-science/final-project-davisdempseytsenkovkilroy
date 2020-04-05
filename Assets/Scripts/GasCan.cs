using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasCan : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    Beaver player;

    private bool pickUpAllowed;
    Canvas mCanvas;

    private void Awake()
    {
        pickUpText = GameObject.Find("PickUpText").GetComponent<Text>();
    }

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        //player = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Beaver>();
    }

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
    }
}
