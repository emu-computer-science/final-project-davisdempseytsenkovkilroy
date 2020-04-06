using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beaver : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] public static int health = 10;
    private Rigidbody2D rb;
    private bool carrying;

    public static bool inZone;

    Text deathText;
    private void Awake()
    {
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
    }
    void Start()
    {
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
    }
    public static bool IsInZone()
    {
        return inZone;
    }
}
