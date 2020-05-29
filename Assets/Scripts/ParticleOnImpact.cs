using UnityEngine;

public class ParticleOnImpact : MonoBehaviour
{
    [SerializeField]
    private ProjectileImpact particlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        particlePrefab.Get<ProjectileImpact>(transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
    }
}
