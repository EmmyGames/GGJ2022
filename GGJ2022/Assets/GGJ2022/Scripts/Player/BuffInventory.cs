using System;
using UnityEngine;

namespace GGJ2022.Player
{
    public class BuffInventory : MonoBehaviour
    {
        public bool[] _buffs = new bool[2];
        public float[] _durations = new float[2];
        
        public void AddBuff(int index, float time)
        {
            _buffs[index] = true;
            _durations[index] = time;

        }

        private void Update()
        {
            Countdown();
        }

        private void Countdown()
        {
            for (int i = 0; i < _durations.Length; i++)
            {
                if (_durations[i] > 0f)
                {
                    //Time.deltaTime accounts for a change in time in Unity
                    _durations[i] -= Time.deltaTime;
                }
                else
                {
                    _buffs[i] = false;
                }
            }
        }

    }
}
