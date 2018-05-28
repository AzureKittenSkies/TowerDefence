using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class BoatController : MonoBehaviour
    {
        public GameObject gameManager;
        public Goal gameScore;

        // Use this for initialization
        void Start()
        {
            gameManager = GameObject.Find("GameManager");
           // gameScore = gameManager.GetComponent<GameManager>();          
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Goal"))
            {
                
            }
        }
    }
}