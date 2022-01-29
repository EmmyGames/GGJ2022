using UnityEngine;

namespace GGJ2022.Guns
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GunStats")]
    public class GunStats : ScriptableObject
    {
        public int currentAmmo;
        public float damage;
        public int magazineSize;
        public float range;
        public float reloadTime;
    }
}
