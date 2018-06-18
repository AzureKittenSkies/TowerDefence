using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    #region Variables
    [Header("Variables")]
    public int lives = 50;
    private int money;
    public bool spearSelected, archerSelected, cannonSelected;
    public bool paused;



    #endregion

    public List<TowerClass> towerList = new List<TowerClass>();


    #region GUIStyles
    [Space(5)]
    [Header("GUIStyles")]
    public GUIStyle livesBox;
    public GUIStyle towerInfoBoxes;
    public GUIStyle spearTowerSelection;
    public GUIStyle archerTowerSelection;
    public GUIStyle cannonTowerSelction;
    public GUIStyle pauseButton;
    #endregion


    void Start()
    {
        towerList.Add(TowerData.CreateTower(0));
        towerList.Add(TowerData.CreateTower(1));
        towerList.Add(TowerData.CreateTower(2));
        money = 100;
    }


    public void Attack(EnemyClass damageData)
    {
        lives -= damageData.Damage;
    }

    public void Update()
    {

    }

    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        if (!paused)
        {
            Time.timeScale = 1;



            GUI.Box(new Rect(14 * scrW, 8 * scrH, 2f * scrW, 1f * scrH), "Lives Left: \n" + lives + "\n Money: \n" + money);



            // Tower selection window
            // background
            GUI.Box(new Rect(0, 0, 5.5f * scrW, 2.75f * scrH), "");

            // Tower option buttons
            if (GUI.Button(new Rect(0.1f * scrW, 0.1f * scrH, 1.6f * scrW, 1.5f * scrH), "Spear Tower"))
            {
                spearSelected = true;
            }
            if (GUI.Button(new Rect(1.95f * scrW, 0.1f * scrH, 1.6f * scrW, 1.5f * scrH), "Archer Tower"))
            {
                archerSelected = true;
            }
            if (GUI.Button(new Rect(3.8f * scrW, 0.1f * scrH, 1.6f * scrW, 1.5f * scrH), "Cannon Tower"))
            {
                cannonSelected = true;
            }

            // Tower info boxes
            GUI.Box(new Rect(0.1f * scrW, 1.75f * scrH, 1.6f * scrW, 0.9f * scrH), "Cost; " + towerList[0].Cost + "\nDamage; " + towerList[0].Damage + "\nRange; " + towerList[0].Range);
            GUI.Box(new Rect(1.95f * scrW, 1.75f * scrH, 1.6f * scrW, 0.9f * scrH), "Cost; " + towerList[1].Cost + "\nDamage; " + towerList[1].Damage + "\nRange; " + towerList[1].Range);
            GUI.Box(new Rect(3.8f * scrW, 1.75f * scrH, 1.6f * scrW, 0.9f * scrH), "Cost; " + towerList[2].Cost + "\nDamage; " + towerList[2].Damage + "\nRange; " + towerList[2].Range);

            // Pause Button
            if (GUI.Button(new Rect(13.9f * scrW, 0.1f * scrH, 2 * scrW, scrH), "Pause Menu", pauseButton))
            {
                paused = true;
            }


        }


        if (paused)
        {
            Time.timeScale = 0;

            // Pause Button


            GUI.Box(new Rect(6.5f * scrW, 2 * scrH, 3 * scrW, 5 * scrH), "Pause menu");

            if (GUI.Button(new Rect(7f * scrW, 5.5f * scrH, 2 * scrW, scrH), "Pause Menu", pauseButton))
            {
                paused = false;
            }

        }
    }
}
