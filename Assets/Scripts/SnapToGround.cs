#if UNITY_EDITOR
using UnityEngine;

[ExecuteInEditMode]
public class SnapToGround : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    private void Update()
    {
        if (layerMask == 0)
        {
            layerMask = LayerMask.GetMask("Default");
        }

        transform.rotation = Quaternion.identity;

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 2f, layerMask))
        {
            transform.position = new Vector3(transform.position.x, hitInfo.point.y, transform.position.z);
        }
    }
}
#endif
