﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    #region Variables
    [Header("Variables")]
    public int lives = 20;
    public int money;
    #endregion

    public List<Tower> towerList = new List<Tower>();


    #region GUIStyles
    [Space(5)]
    [Header("GUIStyles")]
    public GUIStyle livesBox;
    public GUIStyle towerInfoBoxes;
    public GUIStyle spearTowerSelection;
    public GUIStyle archerTowerSelection;
    public GUIStyle cannonTowerSelction;
    #endregion


    void Start()
    {
        towerList.Add(TowerData.CreateTower(0));
        towerList.Add(TowerData.CreateTower(1));
        towerList.Add(TowerData.CreateTower(2));

    }

    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        GUI.Box(new Rect(14 * scrW, 0, 2f * scrW, 1f * scrH), "Lives Left: \n" + lives + "\n Money: \n" + money);
        GUI.Box(new Rect(0, 0, 5.5f * scrW, 2.75f * scrH), "Temp tower Selection window");

        // Tower selection window
        GUI.Box(new Rect(0.1f * scrW, 0, 1.6f * scrW, 1.6f * scrH), "Spear Tower");
        GUI.Box(new Rect(1.95f * scrW, 0, 1.6f * scrW, 1.6f * scrH), "Archer Tower");
        GUI.Box(new Rect(3.8f * scrW, 0, 1.6f * scrW, 1.6f * scrH), "Cannon Tower");

        // Tower info boxes
        GUI.Box(new Rect(0.1f * scrW, 1.6f * scrH, 1.6f * scrW, 1.05f * scrH), "Cost; " + towerList[0].Cost + "\nDamage; " + towerList[0].Damage+ "\nRange; " + towerList[0].Range);
        GUI.Box(new Rect(1.95f * scrW, 1.6f * scrH, 1.6f * scrW, 1.05f * scrH), "Cost; " + towerList[1].Cost + "\nDamage; " + towerList[1].Damage + "\nRange; " + towerList[1].Range);
        GUI.Box(new Rect(3.8f * scrW, 1.6f * scrH, 1.6f * scrW, 1.05f * scrH), "Cost; " + towerList[2].Cost + "\nDamage; " + towerList[2].Damage+ "\nRange; " + towerList[2].Range);


    }
}
