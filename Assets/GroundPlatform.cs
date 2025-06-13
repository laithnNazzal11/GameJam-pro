using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    private void Start()
    {
        // Ensure the platform has a BoxCollider2D component
        if (GetComponent<BoxCollider2D>() == null)
        {
            BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
            collider.isTrigger = false; // Make sure it's not a trigger
        }

        // Set the layer to match the ground layer in PlayerPairController
        gameObject.layer = LayerMask.NameToLayer("Ground");
    }
}