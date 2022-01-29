using GGJ2022.Inventory;
using TMPro;
using UnityEngine;

namespace GGJ2022.UI
{
    public class BuffUI : MonoBehaviour
    {
        public TextMeshProUGUI lightBuff;
        public TextMeshProUGUI darkBuff;

        public Afflictions inventory;

        private void Start()
        {
            inventory.durations[0] = 0;
            inventory.durations[1] = 0;
        }
        private void Update()
        {
            UpdateBuffTimers();
        }

        private void UpdateBuffTimers()
        {
            lightBuff.enabled = !(inventory.durations[0] <= 0);
            darkBuff.enabled = !(inventory.durations[1] <= 0);
            lightBuff.text = "Light: " + Mathf.Ceil(inventory.durations[0]);
            darkBuff.text = "Dark: " + Mathf.Ceil(inventory.durations[1]);
        }
    }
}
