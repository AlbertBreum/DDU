using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    private void Start()
    {
        // Lås cursoren til skærmen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Input fra musen
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Kameraets lodrette rotation (op og ned)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Begræns rotation så spilleren ikke kan kigge bagover

        // Anvend rotation til kameraet
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotér hele spilleren i vandret retning
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
