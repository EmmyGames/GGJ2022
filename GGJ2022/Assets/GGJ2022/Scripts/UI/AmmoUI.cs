using GGJ2022.Guns;
using TMPro;
using UnityEngine;

namespace GGJ2022.UI
{
    public class AmmoUI : MonoBehaviour
    {
        public TextMeshProUGUI currentAmmo;
        public TextMeshProUGUI maxAmmo;
        public GunStats gun;
        private void Start()
        {
            // The gun will always start with a full magazine.
            currentAmmo.text = gun.magazineSize.ToString();
            maxAmmo.text = "/ " + gun.magazineSize.ToString();
        }

        public void UpdateAmmoUI()
        {
            currentAmmo.text = gun.currentAmmo.ToString();
            maxAmmo.text = "/ " + gun.magazineSize.ToString();
        }
    }
}
