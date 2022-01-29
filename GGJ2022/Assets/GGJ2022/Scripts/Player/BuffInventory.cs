using GGJ2022.Inventory;
using UnityEngine;

namespace GGJ2022.Player
{
    public class BuffInventory : MonoBehaviour
    {
        public PlayerScript playerScript;

        public Afflictions inventory;
        // The array of bools isn't really needed. The time is enough.
        //public bool[] buffs = new bool[2];
        //public float[] durations = new float[2];
        
        public void AddBuff(int index, float time)
        {
            inventory.buffs[index] = true;
            inventory.durations[index] = time;
        }

        private void Update()
        {
            Countdown();
        }

        private void Countdown()
        {
            for (int i = 0; i < inventory.durations.Length; i++)
            {
                if (inventory.durations[i] > 0f)
                {
                    //Time.deltaTime accounts for a change in time in Unity
                    inventory.durations[i] -= Time.deltaTime;
                }
                else
                {
                    inventory.buffs[i] = false;
                }
            }
        }
    }
}
