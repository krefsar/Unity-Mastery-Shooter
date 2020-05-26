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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);

        characterController.SimpleMove(transform.forward * vertical * moveSpeed * Time.deltaTime);
    }
}
