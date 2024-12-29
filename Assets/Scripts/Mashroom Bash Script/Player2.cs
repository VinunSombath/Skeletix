using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player2 : MonoBehaviour
{
    public MovementJoyStick2 movementJoyStick2;
    public float playerSpeed;
    private Rigidbody2D rb;

    private Quaternion joystickDirection;

    public float hitRotationAngle = 20f;
    public float hitDuration = 0.2f;

    private bool isJoystickReleased = false;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (movementJoyStick2.joystickVec.magnitude > 0)
        {
            rb.velocity = movementJoyStick2.joystickVec * playerSpeed;

            float angle = Mathf.Atan2(movementJoyStick2.joystickVec.y, movementJoyStick2.joystickVec.x) * Mathf.Rad2Deg;
            joystickDirection = Quaternion.Euler(0, 0, angle);
            transform.rotation = joystickDirection;

            animator.SetFloat("Speed", rb.velocity.magnitude);

            isJoystickReleased = false;
        }
        else
        {
            rb.velocity = Vector2.zero;

            animator.SetFloat("Speed", 0);

            if (!isJoystickReleased)
            {
                StartCoroutine(HitAnimation());
                isJoystickReleased = true;
            }
        }
    }

    IEnumerator HitAnimation()
    {
        float targetAngle = joystickDirection.eulerAngles.z + hitRotationAngle;
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < hitDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(0, 0, targetAngle), elapsedTime / hitDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, targetAngle);

        elapsedTime = 0f;
        startRotation = transform.rotation;

        while (elapsedTime < hitDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, joystickDirection, elapsedTime / hitDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = joystickDirection;
    }
}
