using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Third Person")]
    [SerializeField]
    private CinemachineVirtualCamera followCamera;
    [SerializeField]
    private CinemachineFreeLook freeLookCamera;
    [SerializeField]
    private float thirdPersonMouseLookSensitivity = 1f;

    [Header("First Person")]
    [SerializeField]
    private CinemachineVirtualCamera fpsCamera;
    [SerializeField]
    private float fpsMouseLookSensitivity = 2f;

    [SerializeField]
    private float minAimY = -10f;
    [SerializeField]
    private float maxAimY = 10f;

    private CinemachineComposer aim;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            freeLookCamera.Priority = 100;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        } else if (Input.GetMouseButtonUp(1))
        {
            freeLookCamera.Priority = 0;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }

        if (!Input.GetMouseButton(1))
        {
            float vertical = Input.GetAxis("Mouse Y") * thirdPersonMouseLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, minAimY, maxAimY);
        }

        var fpsVertical = Input.GetAxis("Mouse Y") * fpsMouseLookSensitivity;
        fpsCamera.transform.Rotate(Vector3.right, -fpsVertical);
    }
}
