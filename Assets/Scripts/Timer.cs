using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public float startTime;

	private Text timer;
    private Text textUponTimeEnd;

    private Beaver beaver;
    private bool playerHasMoved;

    private Text showGoal;

    private void Awake()
    {
        textUponTimeEnd = GameObject.Find("DeathText").GetComponent<Text>();
        showGoal = GameObject.Find("PickUpText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
     beaver = GameObject.Find("Beaver").GetComponent<Beaver>();
     timer = GetComponent<Text>();
        timer.text = "Time Remaining: " + (int)startTime;
        playerHasMoved = false;
        showGoal.gameObject.SetActive(true);
        showGoal.text = "Collect all items and destroy them at the dam before time runs out.";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !playerHasMoved)
        {
            playerHasMoved = true;
            showGoal.gameObject.SetActive(false);
        }
            
            if(playerHasMoved) { 
            if (startTime != 0)
            {
                startTime -= Time.deltaTime;
                timer.text = "Time Remaining: " + (int)startTime;
            }

            if (startTime < 1)
            {
                startTime = 0;
                //timer.text = "Time Is Up!";
                textUponTimeEnd.gameObject.SetActive(true);
                textUponTimeEnd.text = "You ran out of time.";
                beaver.Death();
            }
        }
    }
}
