﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Beaver : MonoBehaviour
{
    public enum State
    {
        Idle,
        Moving,
        Dying,
    }

    [SerializeField] float runSpeed = 30f;
    [SerializeField] static int health = 5;
    public int numOfHearts;

    public static bool inDropZone;
    public static bool isCarrying;

    //Text components
    Text deathText;
    Text pickUpText;

    //HeartBar
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //Movement Control
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2d;

    //State Control
    public State state;


    private void Awake()
    {
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
        pickUpText = GameObject.Find("PickUpText").GetComponent<Text>();
    }

    void Start()
    {
        state = State.Idle;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        numOfHearts = health;
        pickUpText.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
    }

    public void Update()
    {
        Debug.Log("State is:" + state);
        CheckState();
        if (state != State.Dying)
        {
            Movement();
        }
        ChangeSpeed();
        CheckHealth();
        CheckWin();
        HealthBar();
    }

    private void CheckState()
    {
        switch (state)
        {
            case State.Idle:
                IdleAnimation();
                break;
            case State.Moving:
                animator.Play("beaver_running");
                break;
            case State.Dying:
                //Change later to death picture
                IdleAnimation();
                Death();
                break;
        }
    }

    private void IdleAnimation()
    {
        animator.Play("beaver_idle");
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            state = State.Dying;
        }
    }

    private void Movement()
    {
        //if no key is pressed
        if (!Input.anyKey)
        {
            state = State.Idle;
        } else
        {
            state = State.Moving;
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                transform.position += transform.right * (Time.deltaTime * runSpeed);
                spriteRenderer.flipX = true;
            }
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                transform.position -= transform.right * (Time.deltaTime * runSpeed);
                spriteRenderer.flipX = false;
            }
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                transform.position += transform.up * (Time.deltaTime * runSpeed);
            }
            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                transform.position -= transform.up * (Time.deltaTime * runSpeed);
            }
        }
    }

    private void ChangeSpeed()
    {

        if (isCarrying)
        {
            runSpeed = 27f;
        }
        else
        {
            runSpeed = 30f;
        }
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
            ShowDeathText();
            deathText.text = "You have won.";
        }
    }

    private void ShowDeathText()
    {
        deathText.gameObject.SetActive(true);
    }

    public static int Health
    {
        get
        {
            return health;
        }
    }

    public void Death()
    {
        StartCoroutine(displayDiedForSeconds(5));
    }
    IEnumerator displayDiedForSeconds(int time)
    {
        deathText.gameObject.SetActive(false);
        ShowDeathText();
        deathText.text = "You have died.";
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator displayMainMenu()
    {
        deathText.text = "Returning to main screen...";
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu");
    }


    //Old movement method, keeping in case we need to revert back to it.
    /*
    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newXpos = transform.position.x + deltaX;

        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasCan" && isCarrying == false && !inDropZone)
        {
            //Debug.Log("Beaver collided with GasCan.");
            ShowPickUpText();
            pickUpText.text = "Press 'F' to pick Gas Can";
        }

        if (collision.gameObject.tag == "Chainsaw" && isCarrying == false && !inDropZone)
        {
            //Debug.Log("Beaver collided with Chainsaw.");
            ShowPickUpText();
            pickUpText.text = "Press 'F' to pick Chainsaw";
        }

        if (collision.gameObject.tag == "Axe" && isCarrying == false && !inDropZone)
        {
            //Debug.Log("Beaver collided with Chainsaw.");
            ShowPickUpText();
            pickUpText.text = "Press 'F' to pick Axe";
        }
    }

    private void ShowPickUpText()
    {
        pickUpText.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasCan" || collision.gameObject.tag == "Chainsaw" || collision.gameObject.tag == "Axe")
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
            inDropZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DropZone")
        {
            //Debug.Log("Beaver has left the DropZone");
            inDropZone = false;
        }
    }

    public static bool IsInZone()
    {
        return inDropZone;
    }
}