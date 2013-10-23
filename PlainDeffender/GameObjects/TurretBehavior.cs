using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /// <summary>
    /// Базовый абстрактный класс для всех турелек
    /// </summary>
    abstract class TurretBehavior : MonoBehaviour
    {
        public GameObject bulletBase;
        public float fireRate = 0.2f;
        float nextFire = 0.0f;

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            
        }

        protected virtual void OpenFire()
        {
            if (Time.time < nextFire) return;
            nextFire = Time.time + fireRate;
            if (bulletBase != null)
            {
                GameObject bullet = (GameObject)Instantiate(bulletBase, transform.position, transform.rotation);
                bullet.transform.Rotate(0, -90, 0);
            }
        }
        
    }
}
