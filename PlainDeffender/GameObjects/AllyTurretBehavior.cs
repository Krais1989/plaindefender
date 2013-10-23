using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    class AllyTurretBehavior : TurretBehavior
    {
        public float fireRange = 10f;

        public float energyDrain = 1;
        public float energyDrainTick = 1f;
        float nextEnergyDrain;

        
        GameObject target;

        protected override void Start()
        {
            base.Start();

            nextEnergyDrain = Time.time + energyDrainTick;
        }

        protected override void Update()
        {
            base.Update();

            bool act = GameInfo.TurretsActivated && GameInfo.HomeEnergy>0;

            Light l = GetComponent<Light>();
            l.enabled = act;

            if (!act)
            {
                return;
            }

            if (Time.time >= nextEnergyDrain)
            {
                nextEnergyDrain = Time.time + energyDrainTick;
                GameInfo.HomeEnergy -= energyDrain;
            }

            if (target != null) { // Атака цели
                Vector3 heading = transform.position - target.transform.position;
                if (heading.sqrMagnitude > fireRange * fireRange)
                {
                    target = null;
                }
                else
                {
                    transform.LookAt(target.transform.position);
                    OpenFire();
                }
            }
            else // Поиск цели
            {
                //transform.Rotate(0, 2, 0);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
                foreach (GameObject enemy in enemies)
                {
                    Vector3 heading = transform.position - enemy.transform.position;
                    if (heading.sqrMagnitude < fireRange * fireRange)
                    {
                        target = enemy;
                        break;
                    }
                }
            }

        }

    }
}
