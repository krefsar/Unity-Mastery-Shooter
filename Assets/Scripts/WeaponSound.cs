using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(AudioSource))]
public class WeaponSound : MonoBehaviour
{
    private Weapon weapon;
    private AudioSource audioSource;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        weapon.OnFire += HandleWeaponFire;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= HandleWeaponFire;
    }

    private void HandleWeaponFire()
    {
        audioSource.Play();
    }
}
