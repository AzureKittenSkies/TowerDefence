using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefence
{
    public class GameManager : MonoBehaviour
    {

        #region Variables
        [Header("Variables")]
        public int lives = 50;
        public int money;
        public bool spearSelected, archerSelected, cannonSelected;
        public bool paused;


        public BoatSpawner boatSpawner;


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
        public GUIStyle towerSelectionBox;
        #endregion


        void Start()
        {
            towerList.Add(TowerData.CreateTower(0));
            towerList.Add(TowerData.CreateTower(1));
            towerList.Add(TowerData.CreateTower(2));
            money = 100;
            boatSpawner = GameObject.Find("Handler").GetComponent<BoatSpawner>();
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



                GUI.Box(new Rect(14 * scrW, 8 * scrH, 2f * scrW, 1f * scrH), "Lives Left: " + lives + "\n Money: " + money, livesBox);
                if (GUI.Button(new Rect(11.75f * scrW, 8 * scrH, 2f * scrW, 1f * scrH), "Next Wave", livesBox))
                {
                    Debug.Log("Next Wave incoming");
                    boatSpawner.nextWave = true;
                }


                // Tower selection window
                // background
                GUI.Box(new Rect(0, 0, 5.5f * scrW, 2.75f * scrH), "");

                // Tower option buttons
                if (GUI.Button(new Rect(0.1f * scrW, 0.1f * scrH, 1.6f * scrW, 1.5f * scrH), "Spear Tower") && money >= TowerData.CreateTower(0).Cost)
                {
                    spearSelected = true;
                    money -= TowerData.CreateTower(0).Cost;
                }
                if (GUI.Button(new Rect(1.95f * scrW, 0.1f * scrH, 1.6f * scrW, 1.5f * scrH), "Archer Tower"))
                {
                    archerSelected = true;
                    money -= TowerData.CreateTower(1).Cost;
                }
                if (GUI.Button(new Rect(3.8f * scrW, 0.1f * scrH, 1.6f * scrW, 1.5f * scrH), "Cannon Tower"))
                {
                    cannonSelected = true;
                    money -= TowerData.CreateTower(2).Cost;
                }

                // Tower info boxes
                GUI.Box(new Rect(0.1f * scrW, 1.75f * scrH, 1.6f * scrW, 0.9f * scrH), "Cost; " + towerList[0].Cost + "\nDamage; " + towerList[0].Damage + "\nRange; " + towerList[0].Range, towerInfoBoxes);
                GUI.Box(new Rect(1.95f * scrW, 1.75f * scrH, 1.6f * scrW, 0.9f * scrH), "Cost; " + towerList[1].Cost + "\nDamage; " + towerList[1].Damage + "\nRange; " + towerList[1].Range, towerInfoBoxes);
                GUI.Box(new Rect(3.8f * scrW, 1.75f * scrH, 1.6f * scrW, 0.9f * scrH), "Cost; " + towerList[2].Cost + "\nDamage; " + towerList[2].Damage + "\nRange; " + towerList[2].Range, towerInfoBoxes );

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


                if (GUI.Button(new Rect(7f * scrW, 4 * scrH, 2 * scrW, scrH), "Resume", pauseButton))
                {
                    paused = false;
                }

                if (GUI.Button(new Rect(7f * scrW, 5.5f * scrH, 2 * scrW, scrH), "Exit to Menu", pauseButton))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }


            }
        }
    }
}