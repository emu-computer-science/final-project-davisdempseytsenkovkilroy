using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public float enemyStop;

    private Transform target;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Transform>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > enemyStop && Beaver.isCarrying) {
            // enemy.gameObject.SetActive(false);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
    }
}
