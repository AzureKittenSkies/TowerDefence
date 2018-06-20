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
        public Vector3 towerPos;
        public float towerHeight;

        public GameObject curTower = null;

        public GameObject[] towerPrefabs;
        private Placeable p = null;
        private Light l = null;



        #endregion



        void Start()
        {
            gameManager = GameObject.Find("Main Camera").GetComponentInChildren<GameManager>();
            towerPrefabs[0] = Resources.Load("Prefabs/Towers/Spear Tower/Spear Tower") as GameObject;
            towerPrefabs[1] = Resources.Load("Prefabs/Towers/Archer Tower/Archer Tower") as GameObject;
            towerPrefabs[2] = Resources.Load("Prefabs/Towers/Cannon Tower/Cannon Tower") as GameObject;

        }

        void Reset()
        {
            p.isPlaced = true;
            l.enabled = false;
        }
        void ClearCache()
        {
            p = null;
            l = null;
            curTower = null;
        }
        void Update()
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(mouseRay, out hit, 1000f, layerMask, QueryTriggerInteraction.Ignore))
                {
                    if (p != null && l != null)
                    {
                        Reset();
                    }

                    p = hit.transform.GetComponent<Placeable>();
                    l = p.GetComponentInChildren<Light>(true);
                    l.enabled = true;


                }
            }

            if (p != null)
            {

                if (gameManager.spearSelected)
                {
                    curTower = towerPrefabs[0];
                    towerHeight = 1.03f;
                }
                if (gameManager.archerSelected)
                {
                    curTower = towerPrefabs[1];
                    towerHeight = 0.65f;

                }
                if (gameManager.cannonSelected)
                {
                    curTower = towerPrefabs[2];
                    towerHeight = 1.13f;

                }


                if (gameManager.spearSelected || 
                    gameManager.archerSelected || 
                    gameManager.cannonSelected)
                {
                    
                    Debug.Log("Spawning a " + curTower.name);
                    towerPos = new Vector3(p.transform.position.x, towerHeight, p.transform.position.z);
                    GameObject clone = Instantiate(curTower, towerPos, Quaternion.identity, GameObject.Find(curTower.name + "s").transform);
                    clone.GetComponent<Tower>().enabled = true;
                    // clone.name = curTower.name;
                    l.enabled = false;
                    gameManager.spearSelected = false;
                    gameManager.archerSelected = false;
                    gameManager.cannonSelected = false;
                    ClearCache();
                    

                }
            }
        }
    }
    // check if tile has anything placed on it
    // if not, then allow tower placement
    // place tower on tile
}
