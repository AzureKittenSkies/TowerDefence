using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    public class Goal : MonoBehaviour
    {

        public float scrW;
        public float scrH;
        public int Lives;

        // Use this for initialization
        void Start()
        {
            scrW = 16;
            scrH = 9;
        }

        // Update is called once per frame
        void Update()
        {
            if (Screen.width / 16 != scrW || Screen.height / 9 != scrH)
            {
                scrW = Screen.width / 16;
                scrH = Screen.height / 9;
            }

        }

        void OnColliderEnter(Collider other)
        {
            // if the other collider has a tag of "enemy"
            if (other.CompareTag("Enemy"))
            {
                // subtract health
                Lives--;
                // destroy object
                Destroy(other);
            }

            
        }

        void OnGUI()
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0 * scrW, 0 * scrH, 2f * scrW, 0.5f * scrH), "Lives left: " + Lives);
        }
    }
}
