using UnityEngine;

public class ThrownObjectCollision : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hitSound; // Assign this sound in the Inspector (same sound for all collisions)

    void Start()
    {
        // Get or add the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Play the hit sound for any collision
        PlayCollisionSound();

        // Check if it hits a brick
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        // Check if it hits a bomb
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        // Check if it hits a wall
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall hit");

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calculate bounce direction
                Vector2 bounceDirection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);

                // Apply bounce velocity
                rb.velocity = bounceDirection * 1f; // Adjust the multiplier to control bounce strength

                // Check if the velocity is zero, and if so, destroy the object
                if (rb.velocity.magnitude <= 0.1f)
                {
                    Destroy(gameObject); // Destroy the thrown object when the velocity is near zero
                }
            }
        }
    }

    // Method to play the hit sound
    private void PlayCollisionSound()
    {
        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        else
        {
            Debug.LogWarning("Hit sound or AudioSource is missing.");
        }
    }
}
