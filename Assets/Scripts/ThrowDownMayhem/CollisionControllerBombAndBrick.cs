using UnityEngine;
using System.Collections.Generic;

public class CollisionControllerBombAndBrick : MonoBehaviour
{
    private GameObject pickedObject = null;

    public Vector3 pickupOffset = new Vector3(28f, 0f, 0f); // Offset for holding the object
    public float throwForce = 1000f; // Force when throwing an object

    private Vector2 lastMovementDirection = Vector2.zero; // Last movement direction for throwing
    public MovementJoyStick joystick; // Joystick reference (assign in Inspector)

    public List<AudioClip> audioClips; // Assign all your audio clips in the Inspector
    private AudioSource audioSource;

    private Dictionary<string, AudioClip> audioClipDict;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on this GameObject.");
        }

        // Initialize the audio clip dictionary
        audioClipDict = new Dictionary<string, AudioClip>();
        foreach (var clip in audioClips)
        {
            if (clip != null)
            {
                audioClipDict[clip.name] = clip; // Map the clip name to the audio clip
            }
        }
    }

    private void PlayAudio(string clipName)
    {
        if (audioClipDict.TryGetValue(clipName, out var clip))
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"AudioClip with name '{clipName}' not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickedObject == null && collision.CompareTag("Brick"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            // Ensure the object is not currently moving
            if (rb != null && rb.velocity == Vector2.zero)
            {
                PlayAudio("pick");
                
                PickUpObject(collision.gameObject);
            }
            else if (rb != null && rb.velocity != Vector2.zero)
            {
                PlayAudio("hit");

                Transform healthSystem = transform.root.Find("HealthSystem"); // Locate the HealthSystem object
                Transform playerHealth = null;

                if (gameObject.name == "1st Player")
                {
                    playerHealth = healthSystem.Find("Player1Health");
                }
                else if (gameObject.name == "2nd Player")
                {
                    playerHealth = healthSystem.Find("Player2Health");
                }

                if (playerHealth != null)
                {
                    // Find the HealthManager on the PlayerHealth object
                    HealthManager healthManager = playerHealth.GetComponent<HealthManager>();
                    if (healthManager != null)
                    {
                        // Let the HealthManager handle the heart destruction
                        healthManager.TakeDamage();
                    }
                    else
                    {
                        Debug.LogError($"HealthManager not found on {playerHealth.name}!");
                    }
                }
                else
                {
                    Debug.LogError("PlayerHealth container not found!");
                }

                Destroy(collision.gameObject); // Destroy the brick
            }

        }
    }


    private void PickUpObject(GameObject obj)
    {
        pickedObject = obj;
        pickedObject.transform.SetParent(transform);
        pickedObject.transform.localPosition = pickupOffset;
        pickedObject.layer = LayerMask.NameToLayer("ThrownObjects");

        Rigidbody2D rb = pickedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Ensure no residual velocity
        }
    }

    private void Update()
    {
        if (joystick == null) return;

        Vector2 joystickDirection = joystick.joystickVec;

        if (joystickDirection == Vector2.zero && pickedObject != null)
        {
            ThrowObject(lastMovementDirection);
        }
        else if (joystickDirection != Vector2.zero)
        {
            lastMovementDirection = joystickDirection;
        }
    }

    private void ThrowObject(Vector2 throwDirection)
    {
        if (pickedObject != null)
        {
            pickedObject.transform.SetParent(null); // Unparent the object to allow independent movement

            Rigidbody2D rb = pickedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Change Rigidbody2D from Kinematic to Dynamic
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

                // Apply throw force
                rb.velocity = throwDirection.normalized * throwForce;
            }

            // Add the collision handling script for specific collisions
            ThrownObjectCollision collisionHandler = pickedObject.AddComponent<ThrownObjectCollision>();

            pickedObject = null;
        }
    }

}
