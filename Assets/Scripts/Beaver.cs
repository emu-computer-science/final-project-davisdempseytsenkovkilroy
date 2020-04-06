using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beaver : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] public static int health = 10;
    private Rigidbody2D rb;

    public static bool inZone;
    public static bool isPickable;

    Text deathText;
    Text pickUpText;

    private void Awake()
    {
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
        pickUpText = GameObject.Find("PickUpText").GetComponent<Text>();
    }

    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            inventory.AddItem(item);
            item.OnPickUp();
        }*/

        //CheckState();

        Move();
        CheckDeath();
        CheckWin();
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            Drop();
        }*/
    }

    /*
    public void Drop()
    {
        if (inZone)
        {
            Scoreboard.score += 1;
        }
    }
    */

    private void CheckWin()
    {
        if (SpawnItems.goal == Scoreboard.score)
        {
            deathText.gameObject.SetActive(true);
            deathText.text = "You have won.";
        }
    }

    public static int Health
    {
        get
        {
            return health;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            deathText.gameObject.SetActive(true);
            //deathText.text = "You have died.";
        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newXpos = transform.position.x + deltaX;

        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DropZone")
        {
            Debug.Log("Beaver collided with DropZone.");
            inZone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasCan")
        {
            Debug.Log("Beaver collided with GasCan.");
            pickUpText.gameObject.SetActive(true);
            pickUpText.text = "Press 'F' to pick Gas Can";
        }

        else if (collision.gameObject.tag == "Chainsaw")
        {
            Debug.Log("Beaver collided with Chainsaw.");
            pickUpText.gameObject.SetActive(true);
            pickUpText.text = "Press 'F' to pick Chainsaw";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasCan" || collision.gameObject.tag == "Chainsaw")
        {
            pickUpText.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DropZone")
        {
            Debug.Log("Beaver has left the DropZone");
            inZone = false;
        }
        if(collision.gameObject.tag == "GasCan" || collision.gameObject.tag == "Chainsaw")
        {
            pickUpText.gameObject.SetActive(false);
        }
    }
    public static bool IsInZone()
    {
        return inZone;
    }
}
