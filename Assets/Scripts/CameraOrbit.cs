using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // Assign the Earth object here
    public float distance = 50f; // Distance from the target
    public float orbitSpeed = 10f; // Speed of orbit
    public float verticalRotationLimit = 80f; // Limit for vertical rotation
    public float zoomSpeed = 10f;

    private float yaw = 0f; // Horizontal rotation angle
    private float pitch = 0f; // Vertical rotation angle

    void Start()
    {
        /*if (target == null)
        {
            Debug.LogError("Target not assigned in CameraOrbit script!");
            return;
        }*/ 

        // Initialize yaw and pitch based on the current camera position
        Vector3 angles = transform.eulerAngles; // Store position in vector3
        yaw = angles.y; // Rotation around y axis
        pitch = angles.x; // Rotaion around x axis
    }

    void Update()
    {
        // Input for horizontal and vertical rotation
        yaw += Input.GetAxis("Mouse X") * orbitSpeed;
        pitch -= Input.GetAxis("Mouse Y") * orbitSpeed;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed; // For zooming in and out
        distance = Mathf.Clamp(distance, 10f, 100f); // Limit the zoom distance

        // Clamp the vertical rotation to avoid flipping the camera
        pitch = Mathf.Clamp(pitch, -verticalRotationLimit, verticalRotationLimit);

        // Calculate the new rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Update the camera rig's position and rotation
        transform.position = target.position - (rotation * Vector3.forward * distance);
        transform.LookAt(target);

    }
}
