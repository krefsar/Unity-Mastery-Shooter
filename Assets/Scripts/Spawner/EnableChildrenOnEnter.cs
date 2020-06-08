using UnityEngine;

public class EnableChildrenOnEnter : MonoBehaviour
{
    [SerializeField]
    private float radius = 15f;

    private void Awake()
    {
        bool state = false;
        ToggleChildren(state);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            ToggleChildren(true);
        }
    }

    private void ToggleChildren(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }

    private void OnValidate()
    {
        var collider = GetComponent<Collider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
            ((SphereCollider)collider).radius = radius;
        }

        collider.isTrigger = true;
    }
}
