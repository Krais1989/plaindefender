using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /// <summary>
    /// Удаляет объект системы частиц после проигрывания
    /// </summary>
    class ParticleSystemBehavior : MonoBehaviour
    {
        void Update()
        {
            if (gameObject.GetComponent<ParticleSystem>().isStopped)
                Destroy(gameObject);

        }
    }
}
