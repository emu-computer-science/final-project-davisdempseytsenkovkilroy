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

    private IEnumerator<Transform> pointInThePath;


    // Start is called before the first frame update
    void Start()
    {
        pointInThePath = AIPath.GetTheNextPoint();

        pointInThePath.MoveNext();

        transform.position = pointInThePath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == MovementTypes.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInThePath.Current.position, Time.deltaTime * moveSpeed);
        }
        else if (type == MovementTypes.LerpTowards)
        {
            transform.position = Vector3.Lerp(transform.position, pointInThePath.Current.position, Time.deltaTime * moveSpeed);
        }

        float dSquared = (transform.position - pointInThePath.Current.position).sqrMagnitude;
        if (dSquared < maxDistanceFromPoint * maxDistanceFromPoint)
        {
            pointInThePath.MoveNext();
        }
    }
}
