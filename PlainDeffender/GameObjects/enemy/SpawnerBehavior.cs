using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PlainDeffender 
{
    /* Логика спавна кубов */
    class SpawnerBehavior : MonoBehaviour
    {
        public GameObject[] enemies; 
        public GameObject[] bonuses;

        public  float enemySpawnPeriod; // Время в секундах между спавнами противника.
                float nextEnemySpawnTime; // 
        public  float enemySpawnCount; // Кол-во спавнов за раз.

        public  float bonusSpawnPeriod; // Время в секундах между спавнами бонуса.
                float nextBonusSpawnTime; // 
        public  float bonusSpawnCount; // Кол-во спавнов за раз.

        public bool         isActive = true;

        Bounds bounds;
        
        public void Start()
        {
            bounds = renderer.bounds;
        }

        public void Update()
        {
            if (!isActive) return;

            if (Time.time >= nextEnemySpawnTime)
            {
                nextEnemySpawnTime = Time.time + enemySpawnPeriod;
                SpawnEnemy();
            }

            if (Time.time >= nextBonusSpawnTime)
            {
                nextBonusSpawnTime = Time.time + bonusSpawnPeriod;
                SpawnBonus();
            }
        }

        public void SpawnBonus()
        {
            GameObject go;
            Vector3 newPos = transform.position;
            float ran = bounds.size.z / 2;

            int bonusIndex = UnityEngine.Random.Range(0, bonuses.Length);

            for (int i = 0; i < enemySpawnCount; i++)
            {
                newPos.z += UnityEngine.Random.Range(-ran, ran);
                go = (GameObject)Instantiate(bonuses[bonusIndex], newPos, Quaternion.identity);
            }
        }

        public void SpawnEnemy()
        {
            GameObject go;
            Vector3 newPos = transform.position;
            float ran = bounds.size.z / 2;

            int emenyIndex = UnityEngine.Random.Range(0, enemies.Length);

            for (int i = 0; i < enemySpawnCount; i++)
            {
                newPos.z += UnityEngine.Random.Range(-ran, ran);
                go = (GameObject)Instantiate(enemies[emenyIndex], newPos, Quaternion.identity);
            }
        }

    }
}
