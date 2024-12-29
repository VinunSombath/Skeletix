using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoyStick : MonoBehaviour
{
    public GameObject joystick;          // The movable stick
    public GameObject joystickBG;       // The fixed background of the joystick
    public Vector2 joystickVec;          // Normalized vector for movement
    private Vector2 joystickTouchPos;    // Center position of the joystick
    private float joystickRadius;        // Radius of the joystick movement limit

    void Start()
    {
        // Set the initial position of the joystick to be fixed at its current location
        joystickTouchPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;

        // Calculate the direction and normalize it
        joystickVec = (dragPos - joystickTouchPos).normalized;

        // Calculate the distance from the center
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        // Restrict the joystick's movement within the radius
        joystick.transform.position = joystickTouchPos + joystickVec * Mathf.Min(joystickDist, joystickRadius);
    }

    public void PointerUp()
    {
        // Reset joystick position and movement vector when touch is released
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickTouchPos;
    }

    // Update() is not needed in this script since the movement is handled in Drag
}
