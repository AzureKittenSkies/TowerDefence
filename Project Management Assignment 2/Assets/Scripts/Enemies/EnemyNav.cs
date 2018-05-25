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
                agent.destination = checkpoint[1].position;
            }
            else
            {
                agent.destination = goal.position;
            }
        }

        void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Checkpoint"))
            {
                if (checkpoint.Length == checkpointIndex + 1)
                {
                    agent.destination = goal.position;
                }
            }
            else
            {
                checkpointIndex++;
                agent.destination = checkpoint[checkpointIndex].position;
                agentDestination = agent.destination;
            }
        }
    }
}