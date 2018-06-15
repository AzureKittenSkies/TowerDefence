using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    #region Variables

    public bool isTileFree;
    public LayerMask layerMask;
    public GameManager gameManager;


    public GameObject[] towerPrefabs;


    #endregion



    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponentInChildren<GameManager>();
    }




    void CheckTileFree(bool isFree)
    {

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, 1000f, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Placeable p = hit.transform.GetComponent<Placeable>();

                if (p && !p.isPlaced)
                {
                    if (gameManager.archerSelected)
                    {

                    }
                }




            }



        }




    }




    // check if tile has anything placed on it
    // if not, then allow tower placement
    // place tower on tile





}
