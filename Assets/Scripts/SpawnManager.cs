using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject[] itemPrefabs;

    private float itemYLowerLimit = 1.0f;
    private float itemYUpperLimit = 2.0f;

    private float obstacleTimerCount = 5.0f;
    private float obstacleMinDelay = 1.0f;
    private float obstacleMaxDelay = 3.0f;

    private float itemTimerCount = 7.0f;
    private float itemMinDelay = 2.0f;
    private float itemMaxDelay = 5.0f;


    // Update is called once per frame
    void Update()
    {
        // only spawn objects and count timers if game is running
        if (GameManager.Instance.IsGameRunning())
        {
            ObstacleTimer();
            if (obstacleTimerCount < 0)
            {
                SpawnRandomObstacle();

                // reset timer
                obstacleTimerCount = Random.Range(obstacleMinDelay, obstacleMaxDelay);
            }

            ItemTimer();
            if (itemTimerCount < 0)
            {
                SpawnRandomItem();
                itemTimerCount = Random.Range(itemMinDelay, itemMaxDelay);
            }
        }

    }

    private void ObstacleTimer()
    {
        obstacleTimerCount -= Time.deltaTime;
    }

    private void SpawnRandomObstacle()
    {
        // select random object and spawn
        int obstacleInt = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[obstacleInt], transform.position, obstaclePrefabs[obstacleInt].transform.rotation);


    }

    private void ItemTimer()
    {
        itemTimerCount -= Time.deltaTime;
    }

    private void SpawnRandomItem()
    {
        // select object and location then spawn
        float itemYLocation = Random.Range(itemYLowerLimit, itemYUpperLimit);
        Vector3 itemSpawnLocation = transform.position + new Vector3(0, itemYLocation, 0);

        int itemInt = Random.Range(0, itemPrefabs.Length);

        Instantiate(itemPrefabs[itemInt], itemSpawnLocation, itemPrefabs[itemInt].transform.rotation);

    }
}
