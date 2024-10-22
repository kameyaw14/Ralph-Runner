using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float verticalAheadDistance; // Vertical offset distance

    private void Update()
    {
        // Apply the vertical offset to the camera's position
        transform.position = new Vector3(transform.position.x, player.position.y + verticalAheadDistance, transform.position.z);
    }
}
