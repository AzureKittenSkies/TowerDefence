using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TestGame
{
    public class BoatScript : MonoBehaviour
    {

        public Transform target;
        private NavMeshAgent agent;
        private Vector3 spawnPoint;

        public GameManager game;
        public GameObject gameManager;

        // Use this for initialization
        void Start()
        {
            spawnPoint = transform.position;
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Contains("Goal"))
            {
                game.lives--;
                Destroy(gameObject);
            }
        }

        private void Reset()
        {
            transform.position = spawnPoint;
        }
    }
}
