using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Rigidbody rb;

    [SerializeField]
    float inputStrenght;

    Vector2 movementInputs = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInputs();
    }

    void FixedUpdate()
    {
        Vector3 forwardDir = player.transform.forward.normalized * movementInputs.y;
        Vector3 rightDir = player.transform.right.normalized * movementInputs.x;   

        rb.AddForce(forwardDir, ForceMode.Force);
        rb.AddForce(rightDir, ForceMode.Force);
    }

    void GetInputs()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movementInputs = new Vector2(inputX * inputStrenght, inputY * inputStrenght);
    }
}
