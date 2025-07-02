using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Move constantly forward
        Vector3 forward = transform.forward * moveSpeed * Time.deltaTime;
        controller.Move(forward);

        // Rotate with horizontal input
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, h * rotationSpeed * Time.deltaTime);
    }
}
