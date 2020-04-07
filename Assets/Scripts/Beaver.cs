using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beaver : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] public static int health = 5;
    public int numOfHearts;
    private Rigidbody2D rb;

    public static bool inZone;
    public static bool isCarrying;

    Text deathText;
    Text pickUpText;

    //HeartBar
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
        pickUpText = GameObject.Find("PickUpText").GetComponent<Text>();
    }

    void Start()
    {
        numOfHearts = health;
        pickUpText.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
    }

    public void Update()
    {
        Move();
        CheckDeath();
        CheckWin();
        HealthBar();
    }

    private void HealthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasCan" && isCarrying == false && !inZone)
        {
            //Debug.Log("Beaver collided with GasCan.");
            pickUpText.gameObject.SetActive(true);
            pickUpText.text = "Press 'F' to pick Gas Can";
        }

        if (collision.gameObject.tag == "Chainsaw" && isCarrying == false && !inZone)
        {
            //Debug.Log("Beaver collided with Chainsaw.");
            pickUpText.gameObject.SetActive(true);
            pickUpText.text = "Press 'F' to pick Chainsaw";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasCan")
        {
            pickUpText.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Chainsaw")
        {
            pickUpText.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
		
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DropZone")
        {
            //Debug.Log("Beaver entered with DropZone.");
            inZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DropZone")
        {
            //Debug.Log("Beaver has left the DropZone");
            inZone = false;
        }
    }

    public static bool IsInZone()
    {
        return inZone;
    }
}
