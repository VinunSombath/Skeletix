using UnityEngine;

public class DetectPlayerCollision : MonoBehaviour
{
    private LayerMask playerLayer;

    // Set the player layer and apply damage if the object collides with the player
    public void SetLayer(LayerMask layer)
    {
        playerLayer = layer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit player");
        Destroy(gameObject);

        // Check if the object collided with a player
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("Hit player in condition");

            // Logic for when the player gets hit by a thrown item
            Debug.Log($"{collision.gameObject.name} was hit by {gameObject.name}");

            // Optionally destroy the thrown object after hitting the player
            Destroy(gameObject);

            // Additional effects such as reducing health can be added here
            // PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            // if (playerHealth != null)
            // {
            //     playerHealth.TakeDamage(10); // Example: deduct 10 health points
            // }
        }
    }
}
