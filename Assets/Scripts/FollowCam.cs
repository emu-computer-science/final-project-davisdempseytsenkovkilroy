using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowCam : MonoBehaviour
{
    private Func<Vector3> GetCameraFollowPositionFunc;

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }
    private void Update()
    {
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDirection = (cameraFollowPosition - transform.position).normalized;       //Smoothing the camera
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        float cameraMoveSpeed = 1f;

        transform.position = transform.position + cameraMoveDirection * distance * cameraMoveSpeed * Time.deltaTime;
    }
}
