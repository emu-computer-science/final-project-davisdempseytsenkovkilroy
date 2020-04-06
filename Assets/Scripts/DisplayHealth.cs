using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public static int health;
    Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        health = Beaver.health;
        if (health > 0)
        {
            healthText.text = "Health: " + health;
        } else
        {
            healthText.text = "Health: 0";
        }
    }
}
