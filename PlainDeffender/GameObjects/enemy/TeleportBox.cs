using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender
{
    class TeleportBox : ExplosionBox
    {
        bool secondLife = true;
        public ParticleSystem teleportEffect;
        public AudioClip teleportSound;

        protected override void Start()
        {
            damage = 20;
            secondLife = true;
            base.Start();
        }

        protected override void Update()
        {
            if (secondLife && hp == 0)
            {
                secondLife = false;
                hp = 1;
                Teleport(-10,10);
            }

            base.Update();
        }

        void Teleport(float min, float max)
        {
            float newX, newZ;
            newX = UnityEngine.Random.Range(min, max);
            newZ = UnityEngine.Random.Range(min, max);
            //transform.position.Set(newX, transform.position.y, newZ);

            
            rigidbody.MovePosition(new Vector3(newX, rigidbody.position.y, newZ));

            if (teleportEffect != null)
            {
                ParticleSystem ps = (ParticleSystem)Instantiate(teleportEffect);
                ps.transform.position = rigidbody.position;
                ps.Play();
            }

            if (teleportSound != null)
            {
                AudioSource.PlayClipAtPoint(teleportSound, CameraManager.current.transform.position);
            }

            if (teleportEffect != null)
                teleportEffect.Play();
        }
    }
}
