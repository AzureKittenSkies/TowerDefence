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
        public Rigidbody rigid;

        public float speed = 5;
        public float rotationSpeed = 10;
        

        #endregion


        #region NavMesh stuff
        /*
        // Use this for initialization
        void Start()
        {

            agent = GetComponent<NavMeshAgent>();
            if (checkpoint.Length != 0 && 
                checkpoint[1] != null)
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

            if (other.CompareTag("Tower Projectile"))
            {
                if (other.name == "Arrow")
                {
                    Debug.Log("That thing is an arrow");
                }
                else if (other.name == "Cannon Ball")
                {
                    Debug.Log("That thing is a cannon ball");
                }
            }
        }
        */
        #endregion


        #region Waypoint Navigation

        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            transform.LookAt(checkpoint[0]);
        }

        void Update()
        {
            rigid.velocity = transform.forward * speed;

            var targetRotation = Quaternion.LookRotation(checkpoint[checkpointIndex].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);



        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("I have hit something");
            if (other.CompareTag("Checkpoint"))
            {
                Debug.Log("It was a checkpoint");
                if (checkpoint.Length >= checkpointIndex + 1)
                {
                    checkpointIndex++;
                    
                }
                else
                {
                    
                }
            }
            if (other.CompareTag("Projectile"))
            {
                Debug.Log("It was a projectile");
            }
        }






        #endregion




    }
}