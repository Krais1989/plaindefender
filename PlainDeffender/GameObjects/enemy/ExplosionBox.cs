using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    public class ExplosionBox : BoxBehavior
    {
        public float    damage = 10;
        public int      scores = 10;

        protected override void Start()
        {
            base.Start();
            startHP = 2;
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
                GameInfo.HomeHealth -= damage;
                Die();
            }
            base.OnCollisionEnter(coll);
        }

        public override void Die()
        {
            GameInfo.currentScores += scores;
            base.Die();
        }
    }
}
