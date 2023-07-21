using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float m_sensitivity = 2500f; // Mouse sensitivity
    public float m_clampAngle = 90f; // Limiting our vertical look angle
    public Transform m_playerObject; // Stores the transform of the player container
    public Transform m_camera; // Stores the transform of the camera

    private Vector2 m_mousePos; // Stores the mouse position
    private float m_xRotation = 0f; // Final vertical rotation value

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos(); // Calls a function to get the mouse position
        FixXRotation(); // Clamps looking up and and down
        LookAt();// Looks at the mouse position

    }

    private void GetMousePos()
    {
        m_mousePos.x = (Input.GetAxis("Mouse X") * m_sensitivity) * Time.deltaTime; 
        m_mousePos.y = (Input.GetAxis("Mouse Y") * m_sensitivity) * Time.deltaTime;
       // Debug.Log(m_mousePos);
    }

    private void FixXRotation()
    {
        m_xRotation -= m_mousePos.y;
        m_xRotation = Mathf.Clamp(m_xRotation, -m_clampAngle, m_clampAngle); //ok so that "-" followed by 2 of the same variables, which is 90 means, "between 0 and 90" because -9+0
    }

    private void LookAt()
    {
        m_camera.localRotation = Quaternion.Euler(m_xRotation, 0, 0); //This is also locking for that 4d math shit you used to studdy dum
        m_playerObject.Rotate(Vector3.up * m_mousePos.x); //This is for that thing you thought about already, makes it so you can't look on dutch angles. Its like rotating a 3d object, if you remember.
    }

}
