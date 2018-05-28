using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefence
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyNav : MonoBehaviour
    {
        #region Variables

        public NavMeshAgent agent;
        public CapsuleCollider baseCollider;

        [Header("Start and End Goals")]
        public Transform start, goal;

        [Header("Checkpoints")]
        public int checkpointIndex;
        public Transform[] checkpoint;

        public Vector3 agentDestination;

        #endregion

        // Use this for initialization
        void Start()
        {

            agent = GetComponent<NavMeshAgent>();
            if (checkpoint.Length != 0 && checkpoint[1] != null)
            {
                agent.SetDestination(checkpoint[1].position);
            }
            else
            {
                agent.SetDestination(goal.position);
            }
        }

        void Update()
        {
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("I have collided with a thing");

            if (other.CompareTag("Checkpoint"))
            {
                Debug.Log("That thing is a checkpoint");

                if (checkpoint.Length == checkpointIndex + 1)
                {
                    agent.SetDestination(goal.position);
                }

                else
                {
                    checkpointIndex++;
                    agent.SetDestination(checkpoint[checkpointIndex].position);
                    agentDestination = agent.destination;
                }
            }

            if (other.CompareTag("Arrow"))
            {
                
            }
        }
    }
}