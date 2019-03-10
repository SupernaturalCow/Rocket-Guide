using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    [SerializeField] float followDistance;

    // Update is called once per frame
    void Update()
    {
        var cameraX = transform.position.x;
        var playerX = GameObject.Find("Player").transform.position.x;
        if (Mathf.Abs(playerX - cameraX) > followDistance)
        {
            cameraX += (playerX - cameraX) * 0.001f;
        }
        transform.position = new Vector3(cameraX, transform.position.y, transform.position.z);
    }
}
