using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float startTime;

	private Text timer;
	private GameObject beaver;
    private Text textUponTimeEnd;

    private void Awake()
    {
        textUponTimeEnd = GameObject.Find("DeathText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
     beaver = GameObject.FindGameObjectWithTag("Beaver");
     timer = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime != 0)
        {
        startTime -= Time.deltaTime;
        timer.text = "Time Remaining: " + (int)startTime;
        }

        if(startTime < 1)
        {
        	startTime = 0;
        	//timer.text = "Time Is Up!";
            textUponTimeEnd.gameObject.SetActive(true);
            textUponTimeEnd.text = "You ran out of time.";

            beaver.SetActive(false);
        }

        
    }
}
