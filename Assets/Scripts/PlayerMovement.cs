using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    [SerializeField]
    private float rotationSpeed = 30f;
    [SerializeField]
    private float moveSpeed = 5f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float mouseHorizontal = Input.GetAxis("Mouse X");

        animator.SetFloat("Speed", vertical);

        if (!Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed * Time.deltaTime);
        }

        characterController.SimpleMove(transform.forward * vertical * moveSpeed * Time.deltaTime);
    }
}
