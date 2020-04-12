using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for a possible future enemy AI, it is not currently being used.

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPos;
    private Vector3 roamPos;

    private void Start()
    {
        startingPos = transform.position;
        roamPos = GetRoamingPos();
    }

    private void Update()
    {
        
    }

    private Vector3 GetRoamingPos()
    {
        return startingPos +  GetRandomDirection() * Random.Range(10f, 70f);
    }

    public Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
