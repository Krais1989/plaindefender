using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender.Menu
{
    /// <summary>
    /// GameOver меню
    /// </summary>
    class GameOverMenu : MonoBehaviour
    {
        float panelWidth, panelHeight;
        float panelX, panelY;
        float btnX, btnWidth, btnHeight;

        private int optSelected;
        float timescale;

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
            if (GameManager.showGameOverMenu)
            {
                GameManager.SetPause(true);
                GUI.Box(new Rect(panelX, panelY, panelWidth, panelHeight), "GAME OVER");
                GUI.BeginGroup(new Rect(panelX, panelY, panelWidth, panelHeight));

                if (GUI.Button(new Rect(panelWidth / 2 - 100, panelHeight / 2, 100, 25), "Restart"))
                {
                    GameManager.showGameOverMenu = false;
                    GameManager.SetPause(false);
                    Application.LoadLevel(1);
                }

                if (GUI.Button(new Rect(panelWidth / 2 + 100, panelHeight / 2, 100, 25), "Main Menu"))
                {
                    GameManager.showGameOverMenu = false;
                    GameManager.SetPause(false);
                    Application.LoadLevel(0);
                }

                GUI.EndGroup();
            }
        }

    }
}
