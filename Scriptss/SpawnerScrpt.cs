
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScrpt : MonoBehaviour
{
    [SerializeField] GameObject[] platforms;
    private float timebtwnSpawn;
    [SerializeField] private float startTimeBtwnSpawn;

    private void Update()
    {
        if(timebtwnSpawn <= 0)
        {
            SpawnPlatform();
           
            timebtwnSpawn = startTimeBtwnSpawn;
        }
        else
        {
            timebtwnSpawn -= Time.deltaTime;
        }
    }

    private void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Length);
        GameObject platformToSpawn = platforms[randomIndex];

        Instantiate(platformToSpawn, transform.position, Quaternion.identity);
    }
}
