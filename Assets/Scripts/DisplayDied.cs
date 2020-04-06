using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDied : MonoBehaviour
{
    public static int health;
    Text deathText;
    private void Awake()
    {
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
    }
    void Start()
    {
        deathText = GetComponent<Text>();
        deathText.gameObject.SetActive(false);
    }

    void Update()
    {
        health = Beaver.health;
        if (health < 1)
        {
            deathText.gameObject.SetActive(true);
            //deathText.text = "You have died.";
        }
    }
}
