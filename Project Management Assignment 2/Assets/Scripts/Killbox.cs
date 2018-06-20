using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{


    void OtherTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("Destroyed projectile");
    }



}
