using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileImpact : PooledMonoBehaviour
{
    private void OnEnable()
    {
        ReturnToPool(1.5f);
    }
}
