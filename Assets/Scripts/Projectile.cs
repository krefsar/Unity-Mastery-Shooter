﻿public class Projectile : PooledMonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        ReturnToPool();
    }
}
