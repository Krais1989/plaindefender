using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    class EnergyBox : BoxBehavior
    {
        public float bonusEnergy = 10;
        protected override void Start()
        {
            startHP = 2;
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void OnCollisionEnter(Collision coll)
        {
            GameObject collObj = coll.gameObject;
            if (collObj.tag == GameTags.homeTag)
            {
                GameInfo.HomeEnergy += bonusEnergy;
                Die();
            }
            base.OnCollisionEnter(coll);
        }
    }
}
