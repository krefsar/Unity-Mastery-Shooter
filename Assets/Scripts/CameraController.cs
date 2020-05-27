using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera followCamera;
    [SerializeField]
    CinemachineFreeLook freeLookCamera;
    [SerializeField]
    private float mouseLookSensitivity = 1f;
    [SerializeField]
    private float minAimY = -10f;
    [SerializeField]
    private float maxAimY = 10f;

    private CinemachineComposer aim;

    private void Awake()
    {
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
            float vertical = Input.GetAxis("Mouse Y") * mouseLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, minAimY, maxAimY);
        }
    }
}
