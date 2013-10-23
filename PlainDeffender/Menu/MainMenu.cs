using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender.Menu
{
    /// <summary>
    /// Подменю.
    /// </summary>
    enum MainMenuWindow
    {
        MMWMain = 0,
        MMWOptions,
        MMWRecords
    }

    /// <summary>
    /// Главное меню. Используется в сцене Menu Scene.
    /// </summary>
    class MainMenu : MonoBehaviour
    {
        float panelWidth, panelHeight;
        float panelX, panelY;
        float btnX, btnWidth, btnHeight;
        MainMenuWindow currentWidnow;

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

        void Awake()
        {
            OnResize();
        }

        void Start()
        {
            currentWidnow   = MainMenuWindow.MMWMain;
            OnResize();
        }

        void DrawMain()
        {
            float btnY, yOffset;
            btnY = 50;

            yOffset = 20;
            
            //if (Debug.isDebugBuild)
            //{
            //    Debug.Log(String.Format("pX:{0} pY:{1} pW:{2} pH:{3} btnX:{4} btnY:{5} btnW:{6} btnH{7} ", 
            //        panelX, panelY, panelWidth, panelHeight, btnX, btnY, btnWidth, btnHeight));
            //}

            GUI.Box(new Rect(panelX, panelY, panelWidth, panelHeight), "Main menu");
            GUI.BeginGroup(new Rect(panelX, panelY, panelWidth, panelHeight));

            if (GUI.Button(new Rect(btnX, btnY, btnWidth, btnHeight), "Start"))
            {
                Application.LoadLevel(1);
            }

            btnY += btnHeight + yOffset;

            if (GUI.Button(new Rect(btnX, btnY, btnWidth, btnHeight), "Options"))
            {
                currentWidnow = MainMenuWindow.MMWOptions;
            }

            btnY += btnHeight + yOffset;

            if (GUI.Button(new Rect(btnX, btnY, btnWidth, btnHeight), "Records"))
            {
                currentWidnow = MainMenuWindow.MMWRecords;
            }

            btnY += btnHeight + yOffset;

            if (GUI.Button(new Rect(btnX, btnY, btnWidth, btnHeight), "Exit"))
            {
                Application.Quit();
            }

            GUI.EndGroup();
        }

        private int optSelected;
        private string[] optTabs = { "Graphics", "Audio", "Game" };
        void DrawOptions()
        {
            GUI.Box(new Rect(panelX, panelY, panelWidth, panelHeight), "Options");
            GUI.BeginGroup(new Rect(panelX, panelY, panelWidth, panelHeight));

            GUI.Box(new Rect(50, 25, panelWidth - 100, panelHeight-50), "");
            optSelected = GUI.SelectionGrid(new Rect(50, 25, panelWidth-100, 25), optSelected, optTabs, 3);
            switch (optSelected)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            if (GUI.Button(new Rect(btnX, panelHeight - (btnHeight * 2), btnWidth, btnHeight), "Back"))
            {
                currentWidnow = MainMenuWindow.MMWMain;
            }

            GUI.EndGroup();
        }

        void DrawRecords()
        {
            GUI.Box(new Rect(panelX, panelY, panelWidth, panelHeight), "Records");
            GUI.BeginGroup(new Rect(panelX, panelY, panelWidth, panelHeight));

            if (GUI.Button(new Rect(btnX, panelHeight - (btnHeight * 2), btnWidth, btnHeight), "Back"))
            {
                currentWidnow = MainMenuWindow.MMWMain;
            }
            GUI.EndGroup();
        }

        void OnGUI()
        {
            OnResize();
            switch (currentWidnow)
            {
                case MainMenuWindow.MMWMain:
                    DrawMain();
                    break;
                case MainMenuWindow.MMWOptions:
                    DrawOptions();
                    break;
                case MainMenuWindow.MMWRecords:
                    DrawRecords();
                    break;
            }

        }
    }
}
