using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject coin;
    [SerializeField] private float timeDelayBetweenSpawn;
    [SerializeField] private float maxHeightOfSpawn;
    private float timeFromLastSpawn;
    private bool isGameActive => GameManager.Instance.isGameActive;

    private void Start()
    {
        timeFromLastSpawn = timeDelayBetweenSpawn;
    }

    private void Update()
    {
        if (!isGameActive) return;

        timeFromLastSpawn += Time.deltaTime;

        if(timeFromLastSpawn >= timeDelayBetweenSpawn)
        {
            SpawnRandomObject();
        }
    }

    private void SpawnRandomObject()
    {
        float chance = Random.Range(0.0f, 1.0f);

        if(chance >= 0.75f)
        {
            SpawnObject(coin);
        }
        else
        {
            SpawnObject(obstacle);
        }
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, Random.Range(-maxHeightOfSpawn, maxHeightOfSpawn));
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        timeFromLastSpawn = 0.0f;
    }
}
