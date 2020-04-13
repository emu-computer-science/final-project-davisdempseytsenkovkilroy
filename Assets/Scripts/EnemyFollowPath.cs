using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    public enum MovementTypes
    {
        MoveTowards, LerpTowards
    }

    public MovementTypes type = MovementTypes.MoveTowards;
    public EnemyMovement AIPath;
    public float moveSpeed = 1f;
    public float maxDistanceFromPoint = .1f;

    public float speed;
    public float enemyStop;
    public float returnToPosSpeed;

    private IEnumerator<Transform> pointInThePath;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        pointInThePath = AIPath.GetTheNextPoint();

        pointInThePath.MoveNext();

        transform.position = pointInThePath.Current.position;

        target = GameObject.FindGameObjectWithTag("Beaver").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > enemyStop && Beaver.isCarrying)
        {
            // enemy.gameObject.SetActive(false);
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = returnToPosSpeed;
            if (type == MovementTypes.MoveTowards)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointInThePath.Current.position, Time.deltaTime * moveSpeed);
            }
            else if (type == MovementTypes.LerpTowards)
            {
                transform.position = Vector3.Lerp(transform.position, pointInThePath.Current.position, Time.deltaTime * moveSpeed);
            }

            var dSquared = (transform.position - pointInThePath.Current.position).sqrMagnitude;
            if (dSquared < maxDistanceFromPoint * maxDistanceFromPoint)
            {
                pointInThePath.MoveNext();
            }
        }
       
    }
}
