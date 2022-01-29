using UnityEngine;

namespace GGJ2022.Inventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Afflictions")]
    public class Afflictions : ScriptableObject
    {
        public bool[] buffs = new bool[2];
        public float[] durations = new float[2];
    }
}
