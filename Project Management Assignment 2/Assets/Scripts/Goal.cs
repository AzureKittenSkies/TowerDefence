using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace TowerDefence
{
    public class Goal : MonoBehaviour
    {

        public float scrW;
        public float scrH;
        public int Lives;

        // Use this for initialization
        void Start()
        {
            scrW = 16; //setting up a 16 * 9 grid over the screen to use for setting up GUI elements
            scrH = 9;
        }

        // Update is called once per frame
        void Update()
        {
            if (Screen.width / 16 != scrW || Screen.height / 9 != scrH)
            {
                scrW = Screen.width / 16; //if the screen is not set to 16 * 9. set the screen to 16 * 9
                scrH = Screen.height / 9;
            }

        }

        void OnTriggerEnter(Collider other)
        {
            // if the other collider has a tag of "enemy"
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit");
                // subtract health
                Lives--;
                // destroy object
                Destroy(other);
            }

            
        }

        void OnGUI()
        {
            GUI.Box(new Rect(0 * scrW, 0 * scrH, 2f * scrW, 0.5f * scrH), "Lives left: " + Lives); //basic UI for life counter
        }
    }
}
