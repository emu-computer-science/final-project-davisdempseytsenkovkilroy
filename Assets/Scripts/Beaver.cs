using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaver : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 10f;
    private Rigidbody2D rb;
    private bool carrying;

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            inventory.AddItem(item);
            item.OnPickUp();
        }*/
        Move();
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
        if (collision.gameObject.tag == "GasCan")
        {
            
        }
    }
}
