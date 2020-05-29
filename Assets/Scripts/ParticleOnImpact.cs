using UnityEngine;

public class ParticleOnImpact : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particlePrefab, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        Destroy(gameObject);
    }
}
