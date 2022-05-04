using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject playerGameObject;

    Vector2 cameraRotationValue = Vector2.zero;
    Transform playerTransform;

    public Vector3 cameraOffset;
    public float mouseSensitivity;

    void Start()
    {
        playerTransform = playerGameObject.transform;
    }

    void Update()
    {
        GetInput();
        CameraRotation();
    }

    void LateUpdate()
    {
        LookAtCharacter();
    }

    void GetInput()
    {
        cameraRotationValue.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        cameraRotationValue.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
    }

    void LookAtCharacter()
    {
        transform.LookAt(playerTransform);
    }

    void CameraRotation()
    {
        Quaternion newRot = Quaternion.Euler(-cameraRotationValue.y, cameraRotationValue.x, 0f);

        playerTransform.rotation = SmoothDamp.Rotate(playerTransform.rotation, newRot, .3f, .5f);
    }
}
