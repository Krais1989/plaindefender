using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /// <summary>
    /// Класс с настройками игры.
    /// !!! Сейчас не используется. !!!
    /// </summary>
    public static class Settings
    {
        /* Graphics settings */
        public static int width;
        public static int height;
        public static bool fullscreenMode;

        /* Audio settings */
        public static float volume;
        // music & sounds volumes is depend on volume property
        public static float musicVolume;
        public static float soundVolume;
        public static bool  musicEnabled;
        public static bool  soundsEnabled;

        /* Игровые настройки */
        public static bool objectLights;
        public static bool explosionEffects;


        static Settings()
        {
            objectLights = true;
            explosionEffects = true;
        }

        /// <summary>
        /// Применяет текущие настройки
        /// </summary>
        public static void Apply()
        {
            Screen.SetResolution(width, height, fullscreenMode);
            AudioListener.volume = volume;
        }

        /// <summary>
        /// Инициализация. Присваиваются дефолтные настройки плеера
        /// </summary>
        public static void Prepare()
        {
            width = Screen.width;
            height = Screen.height;
            fullscreenMode = Screen.fullScreen;
            volume = AudioListener.volume;
            musicVolume = 1.0f;
            soundVolume = 1.0f;
            musicEnabled = true;
            soundsEnabled = true;
        }
    }
}
