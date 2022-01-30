using UnityEngine;
using UnityEngine.AI;

namespace GGJ2022.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform[] spawnLocations;
        public float spawnInterval;
        private int _numberOfEnemies;
        private float _timeSinceSpawn;
        public GameObject[] enemies;
        public int startingSpawnAmount;
        public float speed;
        public int maxEnemies;
        
        private void Start()
        {
            SpawnEnemy(startingSpawnAmount);
        }

        private void Update()
        {
            _timeSinceSpawn += Time.deltaTime;
            if (_timeSinceSpawn >= spawnInterval && _numberOfEnemies < maxEnemies)
            {
                SpawnEnemy(1);
                _timeSinceSpawn = 0f;
            }
        }
        
        private void SpawnEnemy(int num)
        {
            for (var i = 0; i < num; i++)
            {
                var randomEnemy = Random.Range(0, enemies.Length);
                var randomPosition = Random.Range(0, spawnLocations.Length);
                var enemy = Instantiate(enemies[randomEnemy], spawnLocations[randomPosition].position, Quaternion.identity);
                var speedOffset = Random.Range(-4f, 1f);
                enemy.GetComponent<NavMeshAgent>().speed = speed + speedOffset;
                _numberOfEnemies++;
            }
        }

        public void EnemyDied()
        {
            _numberOfEnemies--;
        }
    }
}
