

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    private void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
