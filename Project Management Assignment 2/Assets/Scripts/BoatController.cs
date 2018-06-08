using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefence
{
    public class BoatController : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Goal"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}