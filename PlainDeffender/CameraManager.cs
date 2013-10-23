using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /* Для определения игровых камер через редактор */
    public class CameraList : MonoBehaviour
    {
        /* Имя родительского объекта скрипта должно совпадать с parentName */
        public const string parentName = "CameraList";
        public Camera[] allCameras;

        void Start()
        {

        }

        void Update()
        {

        }
    }

    /// <summary>
    /// Для получения доступа к набору используемых камер CameraList из любой точки приложения
    /// </summary>
    public class CameraManager
    {
        /// <summary>
        /// Импорт набора камер
        /// </summary>
        public static void EnsureCameras()
        {
            GameObject camListObject = GameObject.Find(CameraList.parentName);
            if (camListObject != null)
            {
                cameraList = camListObject.GetComponent<CameraList>().allCameras;
            }
            else if (Debug.isDebugBuild)
            {
                Debug.LogError("Can't find CameraList object.");
            }
        }

        /// <summary>
        /// Список всех используемых камер. Берётся из CameraList.
        /// </summary>
        public static Camera[] cameraList;

        /// <summary>
        /// Индекс текущей камеры в массиве Cameras
        /// </summary>
        private static int currentCameraIndex;

        /// <summary>
        /// Текущая камера.
        /// </summary>
        public static Camera current
        {
            get
            {
                return cameraList[currentCameraIndex];
            }
        }

        /// <summary>
        /// Устанавливает текущую камеру по индексу.
        /// </summary>
        public static void SetCamera(int index)
        {
            if (index<0 || index > cameraList.Length) return;
            currentCameraIndex = index;
            for (int i = 0; i < cameraList.Length; i++)
            {
                cameraList[i].enabled = (i == index);
                cameraList[i].gameObject.SetActive(i == index);
            }
        }

        /// <summary>
        /// Устанавливает главную камеру по имени
        /// </summary>
        /// <param name="name"></param>
        public static void SetCamera(string name)
        {
            for (int i=0; i<cameraList.Length; i++)
            {
                if (String.Equals(cameraList[i].name, name)) {
                    SetCamera(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Переключение на следующую камеру.
        /// </summary>
        public static void NextCamera()
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameraList.Length) currentCameraIndex = 0;
            SetCamera(currentCameraIndex);
        }

    }
}
