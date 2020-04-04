using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public int moveDirection = 1;
    public int moveToPointInPath = 0;
    public Transform[] pathArr;

    public void OnDrawGizmos()
    {
        if (pathArr == null || pathArr.Length < 2)
        {
            return;
        }

        for (int i = 1; i < pathArr.Length; i++)
        {
            Gizmos.DrawLine(pathArr[i - 1].position, pathArr[i].position);
        }

        Gizmos.DrawLine(pathArr[0].position, pathArr[pathArr.Length - 1].position);

    }

    public IEnumerator<Transform> GetTheNextPoint()
    {
        if (pathArr == null || pathArr.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return pathArr[moveToPointInPath];

            if (pathArr.Length == 1)
            {
                continue;
            }



            moveToPointInPath += moveDirection;

            if (moveToPointInPath >= pathArr.Length)
            {
                moveToPointInPath = 0;
            }

            if (moveToPointInPath < 0)
            {
                moveToPointInPath = pathArr.Length - 1;
            }
        }
    }
}
