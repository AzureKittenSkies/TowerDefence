using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public GameObject boatPrefab;
    public Transform enemySpawn;
    public GameObject[] boats;

    int curNum;
    float delay = 2.5f;
    float nextUse;

    // Use this for initialization
    void Start()
    {
        nextUse = Time.time + delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (curNum + 1 > boats.Length)
        {
            curNum = 0;
        }

        boatPrefab = boats[curNum];

        if (Time.time > nextUse)
        {
            nextUse = Time.time + delay;
            GameObject clone = Instantiate(boatPrefab);
            curNum++;
            clone.transform.position = enemySpawn.position;
        }
    }
}
