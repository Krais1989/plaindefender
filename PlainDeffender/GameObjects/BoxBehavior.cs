using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    /// <summary>
    /// Базовый абстрактный класс для передвигающихся объектов (противники, бонусы, снаряды).
    /// </summary>
    /*[RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(BoxCollider))]*/
    public abstract class BoxBehavior : MonoBehaviour
    {
        public ParticleSystem   dieEffect;
        public AudioClip        dieSound;
        
        public      int     startHP = 1;
        protected   int     hp;
        public      float   moveSpeed = 30;

        /* Инициализация компонентов */
        protected virtual void Awake()
        {

        }

        /* Инициализация свойств */
        protected virtual void Start()
        {
            hp = startHP;
        }

        protected virtual void Update()
        {
            if (hp <= 0)
            {
                Die();
            }
        }

        protected virtual void FixedUpdate()
        {
            rigidbody.AddForce(new Vector3(-moveSpeed * Time.deltaTime, 0, 0), ForceMode.Force);
        }

        protected virtual void OnCollisionEnter(Collision coll)
        {
            GameObject collObj = coll.gameObject;
            if (collObj.tag == gameObject.tag)
            {
                Physics.IgnoreCollision(collider, collObj.collider);
            }
        }

        public virtual void ReceiveDamage(GameObject damageDealer)
        {
            BulletBehavior bb = damageDealer.GetComponent<BulletBehavior>();
            if (bb != null)
            {
                hp -= bb.damage;
            }
        }

        public virtual void Die()
        {
            /* Звук разрушения */
            if (dieSound != null)
            {
                AudioSource.PlayClipAtPoint(dieSound, CameraManager.current.transform.position);
            }
            
            /* Эффект разрушения */
            if (dieEffect != null)
            {
                ParticleSystem ps = Instantiate(dieEffect, transform.position, Quaternion.identity) as ParticleSystem;
                ps.transform.position.Set(transform.position.x, transform.position.y, transform.position.z);
                ps.transform.Rotate(-90, 0, 0);
                ps.startColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
                ps.Play();
            }

            Destroy(gameObject);
        }

    }
}
