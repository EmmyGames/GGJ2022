using UnityEngine;

namespace GGJ2022.Buff
{
    public class SpawnBuffs : MonoBehaviour
    {
        public GameObject buffObject;
        public int maxBuffs;
        public int startingBuffAmount;
        public float spawnInterval;
        public Transform[] spawnLocations;
        public float timeSinceSpawn;
        
        private bool[] _isBuffSpawned;
        private int _numberOfBuffs;
        
        private void Start()
        {
            _isBuffSpawned = new bool[spawnLocations.Length];
            SpawnRandomBuffs(startingBuffAmount);
        }
        
        private void Update()
        {
            timeSinceSpawn += Time.deltaTime;
            if (timeSinceSpawn >= spawnInterval && _numberOfBuffs < maxBuffs)
            {
                SpawnRandomBuffs(1);
                timeSinceSpawn = 0f;
            }
        }

        private void SpawnRandomBuffs(int num)
        {
            var i = 0;
            while (i < num)
            {
                var randomPosition = Random.Range(0, spawnLocations.Length);
                if (!_isBuffSpawned[randomPosition])
                {
                    var buff = Instantiate(buffObject, spawnLocations[randomPosition].position, Quaternion.identity);
                    _isBuffSpawned[randomPosition] = true;
                    // Keep track of which index this buff is associated with.
                    buff.GetComponent<BuffController>().spawnIndex = randomPosition;
                    i++;
                }
            }
        }

        public void BuffCollected(int index)
        {
            _isBuffSpawned[index] = false;
            _numberOfBuffs--;
        }
    }
}
