using UnityEngine.EventSystems;
using UnityEngine;

public class MovementJoyStick2 : MonoBehaviour
{
    public GameObject joystick;          // Movable joystick stick
    public GameObject joystickBG;        // Fixed joystick background
    public Vector2 joystickVec;          // Normalized movement vector
    private Vector2 joystickTouchPos;    // Center of joystick background
    private float joystickRadius;        // Radius for joystick movement

    void Start()
    {
        // Set the initial joystick background position as the center
        joystickTouchPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void PointerDown()
    {
        // Do nothing to joystickBG's position; it stays fixed
        // joystickTouchPos is already set to the fixed center
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;

        // Calculate normalized direction vector
        joystickVec = (dragPos - joystickTouchPos).normalized;

        // Calculate the distance from the center
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        // Move the joystick stick within the radius of the background
        joystick.transform.position = joystickTouchPos + joystickVec * Mathf.Min(joystickDist, joystickRadius);
    }

    public void PointerUp()
    {
        // Reset joystick vector and position when released
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickTouchPos; // Reset to the center
    }
}

