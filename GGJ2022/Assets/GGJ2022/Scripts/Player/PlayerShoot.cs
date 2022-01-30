using System.Collections;
using GGJ2022.Enemy;
using GGJ2022.GameEvents;
using GGJ2022.Guns;
using UnityEngine;

namespace GGJ2022.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public ParticleSystem muzzleFlash;
        public PlayerScript playerScript;
        public GunStats gun;
        public UnityEngine.Camera fpsCamera;
        public AudioClip gunShot;
        public float pitchRange;
        private bool _isReloading;

        [SerializeField] private VoidEvent onGunFire;
        [SerializeField] private VoidEvent onGunReload;
        private AudioSource _audioSource;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            gun.currentAmmo = gun.magazineSize;
        }
        public void ShootGun()
        {
            if (_isReloading)
                return;
            PlayGunShot();
            gun.currentAmmo--;
            muzzleFlash.Play();
            onGunFire.Raise();
            
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out var hit, gun.range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
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

        private void PlayGunShot()
        {
            _audioSource.pitch = Random.Range(1 - pitchRange, 1 + pitchRange);
            _audioSource.PlayOneShot(gunShot);
        }
    }
}
