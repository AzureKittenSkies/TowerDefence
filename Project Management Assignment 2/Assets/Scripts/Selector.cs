using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefence
{
    public class Selector : MonoBehaviour
    {
        #region Variables

        public bool isTileFree;
        public LayerMask layerMask;
        public GameManager gameManager;

        public GameObject curTower;

        public GameObject[] towerPrefabs;
        private GameObject[] instances;
        private Transform tower;
        private int currentTower;



        #endregion



        void Start()
        {
            gameManager = GameObject.Find("Main Camera").GetComponentInChildren<GameManager>();
            towerPrefabs[0] = Resources.Load("Prefabs/Towers/Spear Tower/Spear Tower") as GameObject;
            towerPrefabs[1] = Resources.Load("Prefabs/Towers/Archer Tower/Archer Tower") as GameObject;
            towerPrefabs[2] = Resources.Load("Prefabs/Towers/Cannon Tower/Cannon Tower") as GameObject;

        }



        void CheckTileFree(bool isFree)
        {

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, 1000f, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Placeable p = hit.transform.GetComponent<Placeable>();


                    if (p && !p.isPlaced)
                    {
                        p.GetComponentInChildren<Light>().enabled = true;

                        if (gameManager.spearSelected)
                        {
                            Debug.Log("Spawning a " + towerPrefabs[0].name);
                            curTower = Instantiate(towerPrefabs[0], p.transform.position, Quaternion.identity);
                            p.isPlaced = true;

                        }
                        else if (gameManager.archerSelected)
                        {
                            Debug.Log("Spawning a " + towerPrefabs[1].name);

                            curTower = Instantiate(towerPrefabs[1], p.transform.position, Quaternion.identity);

                            p.isPlaced = true;

                        }
                        else if (gameManager.cannonSelected)
                        {
                            Debug.Log("Spawning a " + towerPrefabs[2].name);

                            curTower = Instantiate(towerPrefabs[2], p.transform.position, Quaternion.identity);

                            p.isPlaced = true;
                        }
                    }

                    p.GetComponentInChildren<Light>().enabled = false;



                }



            }




        }




        // check if tile has anything placed on it
        // if not, then allow tower placement
        // place tower on tile





    }
}