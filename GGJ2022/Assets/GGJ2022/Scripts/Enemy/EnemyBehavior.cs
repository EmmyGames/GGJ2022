using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace GGJ2022.Enemy
{
    public class EnemyBehavior : MonoBehaviour
    {
        public EnemyScript enemyScript;

        private GameObject _player;
        private NavMeshAgent _navMeshAgent;
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            _navMeshAgent.destination = _player.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("LossScreen");
            }
        }
    }
}
