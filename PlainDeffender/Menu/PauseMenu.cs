using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender.Menu
{
    /// <summary>
    /// Меню паузы.
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        float panelWidth, panelHeight;
        float panelX, panelY;
        float btnX, btnWidth, btnHeight;

        private int optSelected;
        private string[] optTabs = { "Graphics", "Audio", "Game" };

        void Awake()
        {
            OnResize();
        }

        void Start()
        {
            OnResize();
        }

        void OnResize()
        {
            panelX = 100;
            panelY = 150;
            panelWidth = Screen.width - 200;
            panelHeight = Screen.height / 2;
            btnWidth = Screen.width / 2;
            btnHeight = 30;

            btnX = (panelWidth / 2) - (btnWidth / 2);
        }

        void Update()
        {

        }

        void OnGUI()
        {
            if (GameManager.showPauseMenu)
            {
                OnResize();
                DrawContent();
            }
        }

        void DrawContent()
        {
            GUI.Box(new Rect(panelX, panelY, panelWidth, panelHeight), "Options");
            GUI.BeginGroup(new Rect(panelX, panelY, panelWidth, panelHeight));

            GUI.Box(new Rect(50, 25, panelWidth - 100, panelHeight - 50), "");
            optSelected = GUI.SelectionGrid(new Rect(50, 25, panelWidth - 100, 25), optSelected, optTabs, 3);
            switch (optSelected)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            if (GUI.Button(new Rect(panelWidth - 150, panelHeight - 25, 100, 25), "Restart"))
            {
                GameManager.showGameOverMenu = false;
                GameManager.SetPause(false);
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(panelWidth, panelHeight - 25, 100, 25), "Main Menu"))
            {
                GameManager.showGameOverMenu = false;
                GameManager.SetPause(false);
                Application.LoadLevel(0);
            }

            GUI.EndGroup();
        }

    }

}
