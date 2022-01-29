using System.Collections;
using GGJ2022.Enemy;
using GGJ2022.GameEvents;
using GGJ2022.Guns;
using UnityEngine;

namespace GGJ2022.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public PlayerScript playerScript;
        public GunStats gun;
        public UnityEngine.Camera fpsCamera;
        private bool _isReloading;

        [SerializeField] private VoidEvent onGunFire;
        [SerializeField] private VoidEvent onGunReload;

        private void Start()
        {
            gun.currentAmmo = gun.magazineSize;
        }
        public void ShootGun()
        {
            if (_isReloading)
                return;
            gun.currentAmmo--;
            
            onGunFire.Raise();
            
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out var hit, gun.range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.gameObject.GetComponent<EnemyStats>().TakeDamage(gun.damage);
                }
            }
            
            if (gun.currentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
        }

        public IEnumerator Reload()
        {
            // If we don't need to reload, don't.
            if (gun.currentAmmo == gun.magazineSize)
                yield break;
            _isReloading = true;
            yield return new WaitForSeconds(gun.reloadTime);
            gun.currentAmmo = gun.magazineSize;
            onGunReload.Raise();
            _isReloading = false;
        }
    }
}
