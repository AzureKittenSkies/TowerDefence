using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGUI : MonoBehaviour
{
    #region Variables

    public bool menu = false;
    public Font font;
    public GUIStyle title;
    public GUIStyle buttons;



    #endregion

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;



        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

        GUI.Box(new Rect(2f * scrW, 0.25f * scrH, 12 * scrW, 4.25f * scrH), "Picaroon Prevention", title);

        if (GUI.Button(new Rect(3f * scrW, 5.75f * scrH, 4.5f * scrW, 2.25f * scrH), "Play", buttons))
        {
            SceneManager.LoadScene(1);
        }

        if (GUI.Button(new Rect(9f * scrW, 5.75f * scrH, 4.5f * scrW, 2.25f * scrH), "Exit", buttons))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }







    }









}




