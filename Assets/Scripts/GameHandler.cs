using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public FollowCam followCam;     //Reference for main camera
    public Transform playerTransform;     //Reference for player

    private void Start()
    {
        followCam.Setup(() => playerTransform.position);    //Seting up a dynamic way of following the player
    }
}
