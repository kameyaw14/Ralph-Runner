
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;

    private void Update()
    {
        transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
    }
}
