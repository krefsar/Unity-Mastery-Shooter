using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField]
    private Projectile projectilePrefab;
    [SerializeField]
    private float moveSpeed = 40;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private Transform firePoint;

    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Vector3 direction = weapon.IsInAimMode ? GetDirection() : firePoint.forward;

        var projectile = projectilePrefab.Get<Projectile>(firePoint.position, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * moveSpeed;
    }

    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300f);

        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }

        Vector3 direction = (target - transform.position).normalized;
        return direction;
    }
}