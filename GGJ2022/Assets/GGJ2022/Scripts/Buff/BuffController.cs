using GGJ2022.GameEvents;
using GGJ2022.Player;
using UnityEngine;

namespace GGJ2022.Buff
{
    public class BuffController : MonoBehaviour
    {
        public int index;
        public float time;
        public int spawnIndex;

        [SerializeField] private IntEvent onItemCollect;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // When player enters trigger, runs function AddBuff by passing in index and time through the buff
                other.gameObject.GetComponent<BuffInventory>().AddBuff(index,time);
                onItemCollect.Raise(spawnIndex);
                Destroy(gameObject);
            }
        }
    }
}

    
    