using UnityEngine;

public class Weapon : MonoBehaviour
{
    public KeyCode WeaponHotkey {  get { return weaponHotKey; } }

    [SerializeField]
    private KeyCode weaponHotKey;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (CanFire())
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Debug.Log("Firing weapon " + gameObject.name);
    }

    private bool CanFire()
    {
        return true;
    }
}
