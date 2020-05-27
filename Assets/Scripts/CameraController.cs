using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera followCamera;
    [SerializeField]
    private float mouseLookSensitivity = 1f;

    private CinemachineComposer aim;

    private void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    private void Update()
    {
        var vertical = Input.GetAxis("Mouse Y") * mouseLookSensitivity;
        aim.m_TrackedObjectOffset.y += vertical;
    }
}
