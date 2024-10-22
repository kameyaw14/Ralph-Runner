using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] platforms;
    private float timebtwnSpawn;
    [SerializeField] private float startTimeBtwnSpawn;
    [SerializeField] private float decreaseTime;
    [SerializeField] float minTime = 0.65f;

    private void Update()
    {
        if (timebtwnSpawn <= 0)
        {
            SpawnPlatform();

            timebtwnSpawn = startTimeBtwnSpawn;
            if(startTimeBtwnSpawn > minTime)
            {
                startTimeBtwnSpawn -= decreaseTime;
            }
        }
        else
        {
            timebtwnSpawn -= Time.deltaTime;
        }
    }

    private void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Length);


        Instantiate(platforms[randomIndex], transform.position, Quaternion.identity);
    }
}
