using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /// <summary>
    /// Класс снаряда.
    /// </summary>
    class BulletBehavior : BoxBehavior
    {
        public float lifeTime = 3.0f;
        float timeToDie = 0.0f;
        public int damage = 1;

        public AudioClip fireSound;

        protected override void Awake()
        {
            moveSpeed = 30.0f;
        }

        protected override void Start()
        {
            timeToDie = Time.time + lifeTime;

            if (fireSound != null)
            {
                AudioSource.PlayClipAtPoint(fireSound, CameraManager.current.transform.position);
            }

            base.Start();
        }

        protected override void Update()
        {
            base.Update();

            if (hp<=0 || Time.time > timeToDie)
            {
                Die();
            }
            //transform.Translate(transform.up * moveSpeed * Time.deltaTime);
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

        void OnTriggerEnter(Collider collider)
        {
            GameObject go = collider.gameObject;
            if (go.tag == GameTags.enemyTag ||
                go.tag == GameTags.bonusTag)
            {
                go.GetComponent<BoxBehavior>().ReceiveDamage(this.gameObject);
                hp--;
            }

            if (go.tag == GameTags.wallTag)
            {
                Die();
            }

        }

        protected override void FixedUpdate()
        {
        }
    }
}
