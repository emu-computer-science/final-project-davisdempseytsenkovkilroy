using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointer : MonoBehaviour
{
	public Transform target;

    // Update is called once per frame
    void Update()
    {
     var direction = target.position - transform.position;
     var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
