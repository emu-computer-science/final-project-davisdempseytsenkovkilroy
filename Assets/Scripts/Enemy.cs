using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    private Beaver player;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Beaver")
        {
            player = collision.gameObject.GetComponent<Beaver>();
            Debug.Log("Collision with player.");
            player.TakeDamage(damage);
        }
    }
}
