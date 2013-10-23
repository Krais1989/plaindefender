using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /// <summary>
    /// Класс для работы с общеигровым событиями.
    /// </summary>
    class GameManager : MonoBehaviour
    {
        private static float _curTimeScale;
        /* Состояние игры */
        public static bool isPaused         = false;
        public static bool showPauseMenu    = false;
        public static bool showGameOverMenu = false;

        public static void TooglePause()
        {
            SetPause(!isPaused);
        }

        public static void SetPause(bool val)
        {
            if (val != isPaused) // 
            {
                isPaused = val;
                if (isPaused)
                {
                    _curTimeScale = Time.timeScale;
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = _curTimeScale;
                }
            }
        }


        public static void Restart()
        {
        }

        void Start()
        {
            GameInfo.Reset();
            CameraManager.EnsureCameras();
            CameraManager.SetCamera(0);
        }

        void Update()
        {
            /* Сменить камеру */
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                CameraManager.NextCamera();
            }

            /* Пауза */
            if (Input.GetKeyDown(KeyCode.Escape) && !showGameOverMenu)
            {
                showPauseMenu = !showPauseMenu;
                SetPause(showPauseMenu);
            }

            /* GameOver */
            if (GameInfo.HomeHealth <= 0)
            {
                showGameOverMenu = true;
                SetPause(showGameOverMenu);
            }

            /* No energy */
            if (GameInfo.HomeEnergy <= 0)
            {
                GameInfo.TurretsActivated = false;
            }

            /* Активация турелек */
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameInfo.TurretsActivated = !GameInfo.TurretsActivated;
            }

            /* Level UP */
            if (GameInfo.currentScores >= GameInfo.nextLevelScores)
            {
                GameInfo.level++;
                GameInfo.nextLevelScores = GameInfo.currentScores + GameInfo.level*100;
            }
        }

        public float barWidth = 2;
        /* Отрисовка интерфейса */
        void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 200, 100), "");
            GUI.BeginGroup(new Rect(10,10,200,100));

            GUI.Label(new Rect(0, 0,  150,20), String.Format("Health: {0}%", GameInfo.HomeHealth.ToString()));
            GUI.Label(new Rect(0, 25, 150, 20), String.Format("Energy: {0}%", GameInfo.HomeEnergy.ToString()));
            GUI.Label(new Rect(0, 50, 150, 20), String.Format("Ally turrets: {0}", GameInfo.TurretsActivated?"ON":"OFF"));
            GUI.Label(new Rect(0, 75, 150, 20), String.Format("Level: {0}  Exp:{1}/{2}", GameInfo.level.ToString(), GameInfo.currentScores.ToString(), GameInfo.nextLevelScores.ToString()));
            GUI.EndGroup();

        }
    }


    /// <summary>
    /// Класс с игровыми данными.
    /// </summary>
    class GameInfo
    {
        /* Уровень, очки */
        public static int currentScores;
        public static int nextLevelScores;
        public static int level;

        /* Флаг активности союзных турелек */
        public static bool TurretsActivated;

        /* Достижения игрока */
        public static int accurancy;
        public static int shootCount;
        public static int hitCount;

        /* Здоровье */
        private static float _homeHealth;
        public static float HomeHealth
        {
            get {
                return _homeHealth;
            }
            set
            {
                _homeHealth = value;
                if (_homeHealth > 100) _homeHealth = 100;
            }
        }

        /* Энергия */
        private static float _homeEnergy;
        public static float HomeEnergy
        {
            get
            {
                return _homeEnergy;
            }
            set
            {
                _homeEnergy = value;
                if (_homeEnergy > 100) _homeEnergy = 100;
            }
        }

        /// <summary>
        /// Обнуление игровых данных.
        /// </summary>
        public static void Reset() 
        {


            // При первом GameManager.Update() level апнется на 1 и nextLevelScores соответсвтвенно.
            currentScores = 0;
            nextLevelScores = 0;
            level       = 0; 

            /* Игрок */
            currentScores = 0;
            accurancy   = 0;
            shootCount  = 0;
            hitCount    = 0;
            
            /* База */
            HomeHealth  = 100;
            HomeEnergy  = 100;

            TurretsActivated = true;
        }
    }
}
