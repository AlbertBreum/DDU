using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    public GameObject targetObject;  // Det GameObject som har scriptet, der skal fjernes

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock rotation så spilleren ikke vælter under bevægelse
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Input fra WASD eller piletaster
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Flyt spilleren
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

        // Hop
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetMouseButtonDown(1))  // 1 betyder højre museknap
        {
            if (targetObject != null)
            {
                // Find det script på targetObject, som du vil fjerne
                var script = targetObject.GetComponent<Plague>();  // Udskift PlayerMovement med det script, du vil fjerne
                if (script != null)
                {
                    // Fjern scriptet
                    Destroy(script);
                    Debug.Log("Script fjernet fra " + targetObject.name);
                }
                else
                {
                    Debug.Log("Scriptet findes ikke på " + targetObject.name);
                }
            }
        }
    }

    // Check om spilleren står på jorden
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    
}
