using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasCan : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    Beaver player;

    public static bool isHeld = false;
    public GameObject gasCanPrefab;

    private bool pickUpAllowed;
    private Transform beaver;
    Canvas mCanvas;

    private void Awake()
    {
        pickUpText = GameObject.Find("PickUpText").GetComponent<Text>();
        gasCanPrefab = GameObject.FindGameObjectWithTag("GasCan");
    }

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        beaver = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Transform>();
        //player = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Beaver>();
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("Drop" , 0.1f);
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
    }
    public static bool IsHeld()
    {
        return isHeld;
    }
}
