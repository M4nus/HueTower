using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_platform : MonoBehaviour
{

    public GameObject platformPrefab;

    public int numberOfPlatforms;

    public float LevelWidth;

    public float minY;

    public float maxY;

    // Use this for initialization
    void Start()
    {

        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {

            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-LevelWidth, LevelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
