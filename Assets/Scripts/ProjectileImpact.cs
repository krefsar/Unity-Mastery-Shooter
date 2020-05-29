public class ProjectileImpact : PooledMonoBehaviour
{
    private void OnEnable()
    {
        ReturnToPool(1.5f);
    }
}
