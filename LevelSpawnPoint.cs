using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnPoint : MonoBehaviour
{
    public GameObject[] levels; // Corrected variable name to be plural for clarity

    private void Start()
    {
        foreach (GameObject obstacle in levels)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
        }
    }
}
