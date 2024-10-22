using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeMovement : MonoBehaviour
{
    [SerializeField] private float Speed;

    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
