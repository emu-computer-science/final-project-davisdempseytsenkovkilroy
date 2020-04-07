using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    public static int health = 5;
	public int numOfHearts = 5;
	
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	
	private GameObject player;
	
	Text deathText;
	public void Awake() {
		player = GameObject.FindGameObjectWithTag("Beaver");
		//player = GameObject.Find("Beaver");
		deathText = GameObject.Find("DeathText").GetComponent<Text>();
	}
	
	public static void TakeDamage(int damage)
    {
        health = health - damage;
    }
	
	void Update()
	{
		
		if(health < 1)
		{
			player.gameObject.SetActive(false);
			deathText.gameObject.SetActive(true);
		}
		
		if(health > numOfHearts)
		{
			health = numOfHearts;
		}
		
		for(int i = 0; i < hearts.Length; i++)
		{	
			if(i < health) 
			{
				hearts[i].sprite = fullHeart;
			} else {
				hearts[i].sprite = emptyHeart;
			}
			
			if(i < numOfHearts)
			{
				hearts[i].enabled = true;
			} else {
				hearts[i].enabled = false;
			}
		}
	}
	
}
