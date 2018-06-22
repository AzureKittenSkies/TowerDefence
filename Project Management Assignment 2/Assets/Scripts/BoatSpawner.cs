using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class BoatSpawner : MonoBehaviour
    {
        public Transform enemySpawn;
        public GameObject[] boats;

        public GameObject enemyParent;
        public GameObject gameManager;

        public bool playing = true;
        public bool nextWave;

        // setting number of enemies spawned per wave
        // enemies: {small, medium, large}

        public Vector3[] waveVectorSpawn;

        int curNum;
        public float delay = 7.5f;
        float nextUse;
        int curWave = 0;

        // Use this for initialization
        void Start()
        {
            waveVectorSpawn = new[] { new Vector3(1, 0, 0), new Vector3(3, 0, 0), new Vector3(0, 1, 0), new Vector3(2, 1, 0),
                new Vector3(3, 3, 0), new Vector3(3, 0, 1), new Vector3(5, 5, 1), new Vector3(7, 3, 3), new Vector3(7, 5, 5),
                new Vector3(10, 7, 7), new Vector3(15, 5, 5), new Vector3(25, 0, 0), new Vector3(13, 7, 5), new Vector3(17, 12, 7)};
            enemyParent = GameObject.Find("Enemies");
        }

        // Update is called once per frame
        void Update()
        {
            if (playing)
            {
                nextUse += Time.deltaTime;
                if (nextWave && nextUse >= delay)
                {
                    int noToSpawn;

                    noToSpawn = (int)waveVectorSpawn[curWave].x;
                    for (int x = 0; x < noToSpawn; x++)
                    {
                        Debug.Log("Spawning a raft");
                        Instantiate(boats[0], (Random.insideUnitSphere * 3) + enemySpawn.transform.position, Quaternion.identity, enemyParent.transform);
                    }

                    noToSpawn = (int)waveVectorSpawn[curWave].y;
                    for (int y = 0; y < noToSpawn; y++)
                    {
                        Instantiate(boats[1], enemySpawn.transform.position, Quaternion.identity, enemyParent.transform);
                    }

                    noToSpawn = (int)waveVectorSpawn[curWave].z;
                    for (int z = 0; z < noToSpawn; z++)
                    {
                        Instantiate(boats[2], enemySpawn.transform.position, Quaternion.identity, enemyParent.transform);
                    }
                    curWave++;
                    nextUse = 0;
                    nextWave = false;
                }
            }

            /*
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
            */

        }
    }

}