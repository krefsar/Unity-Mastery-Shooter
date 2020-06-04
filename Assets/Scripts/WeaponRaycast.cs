using UnityEngine;

public class WeaponRaycast : WeaponComponent
{
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private PooledMonoBehaviour decalPrefab;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private int damage = 1;

    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Ray ray = weapon.IsInAimMode ?
            Camera.main.ViewportPointToRay(Vector3.one / 2f) :
            new Ray(firePoint.position, firePoint.forward);

        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            Health health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeHit(damage);
            } else
            {
                SpawnDecal(hitInfo.point, hitInfo.normal);
            }

        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        // this will spawn a quad, which only renders on one side, so we need to invert it (-normal) to see the decal
        var decal = decalPrefab.Get<PooledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(5f);
    }
}
