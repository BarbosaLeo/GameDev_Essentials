using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public Transform cameraOffset;

    [SerializeField]
    [Range(1, 100)]
    int mouseSensitivity = 5;
    float moveSpeed = 1.6f;
    float verticalSpeed = 0f;

    private Vector3 direction = Vector3.zero;
    private Vector3 movement = Vector3.zero;
    private Vector2 mouseMovement = Vector2.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void GetInputs()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");

        Vector3 inputs = new Vector3 (xInput, 0, yInput);
        Vector2 mouseInputs = new Vector2 (xMouse, -yMouse);

        movement = inputs * moveSpeed;
        mouseMovement = mouseInputs * mouseSensitivity;

        RotateCharacter();
    }

    private void MoveCharacter()
    {
        if (characterController != null)
        {
            Gravity();
            if(movement != Vector3.zero)
            {
                direction = movement;
                direction = transform.TransformDirection(direction);

                characterController.Move(direction * Time.fixedDeltaTime);
            }
        }
    }

    private void RotateCharacter()
    {
        if (cameraOffset != null)
        {
            cameraOffset.Rotate(new Vector3(mouseMovement.y, 0f, 0f), Space.Self);
        }

        transform.Rotate(new Vector3(0f, mouseMovement.x, 0f));
    }

    private void Gravity()
    {
        if (characterController.isGrounded)
        {
            verticalSpeed = 0f;
        }

        verticalSpeed -= 9.8f * Time.fixedDeltaTime;
        movement.y = verticalSpeed;
    }
}
