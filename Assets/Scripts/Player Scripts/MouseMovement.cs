using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    float horizontalSensitivity = 5.0f;
    [SerializeField]
    float verticallSensitivity = 5.0f;
    [SerializeField]
    float smoothing = 2.0f;
    [SerializeField]
    float yMaxRange = 4.5f;
    [SerializeField]
    float yMinRange = -30f;

    Vector2 mouseLook;
    Vector2 smoothVector;

    [SerializeField]
    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        mouseLook = new Vector2(0, -transform.eulerAngles.x);
    }

    public void RespondToMouseMovement()
    {
        UpdateSmoothVector();
        mouseLook += smoothVector;
        CheckExceedingLimits();
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right); //Rotate the camera Verically
        character.transform.Rotate(0, mouseLook.x, 0, Space.Self); //Rotate the player Horizontally
        mouseLook.x = 0; //No need for accumulation
    }

    private void UpdateSmoothVector()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(horizontalSensitivity * smoothing, verticallSensitivity * smoothing));

        smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
        smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);
    }

    private void CheckExceedingLimits()
    {
        if (mouseLook.y > yMaxRange)
        {
            mouseLook.y = yMaxRange;
        }
        else if (mouseLook.y < yMinRange)
        {
            mouseLook.y = yMinRange;
        }
    }
}
