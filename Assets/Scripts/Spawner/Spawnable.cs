using UnityEngine;

public class Spawnable : PooledMonoBehaviour
{
    [SerializeField]
    private float returnToPoolDelay = 10f;

    private void Start()
    {
        if (GetComponent<Health>() != null)
        {
            GetComponent<Health>().OnDied += HandleDied;
        }
    }

    private void HandleDied()
    {
        ReturnToPool(returnToPoolDelay);
    }
}
