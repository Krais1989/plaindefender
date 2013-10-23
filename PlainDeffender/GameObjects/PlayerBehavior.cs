using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /// <summary>
    /// Класс игрока.
    /// </summary>
    class PlayerBehavior : TurretBehavior
    {
        protected override void Start()
        {
            base.Start();
            fireRate = 0.2f;
        }

        protected override void Update()
        {
            base.Update();

            if (GameManager.isPaused) return;

            /* Поворачиваем пушку к указателю мыши */
            Ray ray = CameraManager.current.ScreenPointToRay(Input.mousePosition);
            /* Находим угол наклона луча */
            Vector3 rayVec = ray.origin + ray.direction;
            Vector3 vxz = new Vector3(ray.direction.x, 0, ray.direction.z); // Вектор, лежащий в плоскости XZ.
            float angleDeg = Vector3.Angle(rayVec, vxz);
            /* Дистанция луча до плоскости в которой лежит точка появления снаряда */
            float dist = (CameraManager.current.transform.position.y - transform.position.y) / Mathf.Sin(Mathf.Deg2Rad * angleDeg);

            /*  */
            Vector3 fireDir = ray.GetPoint(dist);
            fireDir.y = transform.position.y;
            transform.LookAt(fireDir);

            if (Input.GetMouseButton(0))
            {
                OpenFire();
                GameInfo.shootCount++;
            }
        }
    }
}
