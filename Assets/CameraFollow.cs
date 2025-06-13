using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign PlayerOne's transform in the Inspector
    public Vector3 offset = new Vector3(-5, 5, -10); // Default offset, camera starts to the left
    public float smoothSpeed = 0.125f; // Smoothing factor
    private float initialY;
    private float initialZ;
    public float minX = 0f; // Minimum x position for the camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = target.position.x + offset.x;
            newPosition.y = initialY;
            newPosition.z = initialZ;
            // Clamp camera x so player never goes past the left edge
            newPosition.x = Mathf.Max(newPosition.x, minX);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
