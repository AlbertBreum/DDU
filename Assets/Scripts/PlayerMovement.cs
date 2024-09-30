using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    public GameObject targetObject;  // Det GameObject som har scriptet, der skal fjernes
    public NPCSpawner spawner;
    public float radius = 5f;
    public Transform player;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock rotation s� spilleren ikke v�lter under bev�gelse
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
        if (Input.GetMouseButtonDown(0))  // 0 = Mouse0 (venstre museknap)
        {
            // G� igennem alle de spawnede objekter
            foreach (GameObject spawnedObject in spawner.spawnedObjects)
            {
                // Beregn afstanden fra spilleren til det spawnede objekt
                float distance = Vector3.Distance(player.position, spawnedObject.transform.position);

                // Hvis afstanden er mindre end radiusen, fjern PlayerMovement scriptet
                if (distance <= radius)
                {
                    var script = spawnedObject.GetComponent<Plague>();
                    if (script != null)
                    {
                        Destroy(script);  // Fjern scriptet
                        Debug.Log("Script fjernet fra " + spawnedObject.name + " inden for radiusen.");
                    }
                }
            }
        }
    }
    // Check om spilleren st�r p� jorden
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    
}
