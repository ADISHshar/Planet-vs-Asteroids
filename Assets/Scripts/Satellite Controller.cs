using UnityEngine;

public class SatelliteController : MonoBehaviour
{
   public float rotationSpeed = 50f;

    void Update()
    {
        // Rotate around Earth based on input
        float horizontal = Input.GetAxis("Horizontal"); // Left/Right rotation
        float vertical = Input.GetAxis("Vertical"); // Up/Down rotation

        transform.RotateAround(Vector3.zero, Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
        transform.RotateAround(Vector3.zero, transform.right, vertical * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject); // Destroy asteroid
            
            //audio and vistuals

        }
    }
}

