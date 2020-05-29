using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private float velocity = 40;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float maxDistance = 100f;

    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Vector3 direction = GetDirection();

        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(direction));
        projectile.velocity = direction * velocity;
    }

    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        Vector3 target = ray.GetPoint(300f);

        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }

        Vector3 direction = (target - transform.position).normalized;
        return direction;
    }
}