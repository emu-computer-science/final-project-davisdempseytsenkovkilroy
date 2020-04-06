using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    [SerializeField] private Text dropText;

    private bool dropAllowed;
    private Transform beaver;
    Canvas mCanvas;
    public GameObject gasCanPrefabNoText;

    private void Awake()
    {
        dropText = GameObject.Find("DropText").GetComponent<Text>();
        gasCanPrefabNoText = GameObject.FindGameObjectWithTag("GasCanNoText");
    }

    private void Start()
    {
        dropText.gameObject.SetActive(false);
        beaver = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Transform>();
        //player = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Beaver>();
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Drop();
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beaver")
        {
            Debug.Log("Collision with beaver detected.");
            if (GasCan.isHeld)
            {
                dropText.gameObject.SetActive(true);
                dropAllowed = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beaver")
        {
            dropText.gameObject.SetActive(false);
            dropAllowed = false;
        }
    }

    /*
    public void Drop()
    {
        if (dropAllowed && GasCan.IsHeld())
        {
            if (Beaver.IsInZone())
            {
                Scoreboard.score += 1;
                //GameObject gasCan = Instantiate<GameObject>(gasCanPrefabNoText);
                GameObject anchor = GameObject.Find("DropZone");
                //GameObject gasCan = Instantiate<GameObject>(gasCanPrefabNoText);
                //GameObject gasCan = Instantiate(Resources.Load("gas can")) as GameObject;
                //GameObject gasCan = Instantiate<GameObject>(gasCanPrefabNoText);
                //gasCan.transform.position = beaver.position;
                //gasCan.transform.SetParent(anchor.transform);
               //dropAllowed = false;
                //GasCan.isHeld = false;
            }
        }
    }
    */
}
