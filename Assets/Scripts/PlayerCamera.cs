using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public bool followX = true;
    public bool followY = false;

    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - player.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + offset;
        if (!followX)
        {
            newPosition.x = transform.position.x;
        }
        if (!followY)
        {
            newPosition.y = transform.position.y;
        }
        transform.position = newPosition;
    }
}
