using UnityEngine;

namespace GGJ2022.GameEvents
{
    /// <summary>
    /// Allows people to create new int events that can be raised
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/Game Event/Int Event")]
    public class IntEvent : BaseGameEvent<int> { }
}