using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public KeyCode m_forward;
    public KeyCode m_back;
    public KeyCode m_left;
    public KeyCode m_right;
    public KeyCode m_sprint;
    public KeyCode m_jump;


    public UnityEngine.CharacterController m_charController;
    public float m_movementSpeed = 12f;

    public float m_gravity = -15f;
    private Vector3 m_velocity;

    private float m_finalSpeed = 0;
    public float m_runSpeed = 3f;

    public float m_jumpHeight = 3f;
    public Transform m_groundCheckPoint;
    public float m_groundDistance = 0.4f;
    public LayerMask m_groundMask;
    public bool m_isGrounded;
    public bool isFalling;



    // Start is called before the first frame update
    void Awake()
    {
        m_finalSpeed = m_movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //isFalling = FallCheck();
        m_isGrounded = HitGroundCheck();
        MoveInputCheck();

    }

    
    void MoveInputCheck()
    {
        float x = Input.GetAxis("Horizontal"); //X
        float z = Input.GetAxis("Vertical"); //Z imput, gets it

        Vector3 move = Vector3.zero;

        if (Input.GetKey(m_forward) || Input.GetKey(m_back) || Input.GetKey(m_left) || Input.GetKey(m_right))
        {
            move = transform.right * x + transform.forward * z; //move vector asshole
        }
        MovePlayer(move);
        RunCheck();
        JumpCheck(); //check we jumpy jump
    }

    void MovePlayer(Vector3 move)
    {
        m_charController.Move(move * m_finalSpeed * Time.deltaTime); // Stuff from WASD
        m_velocity.y += (1.2f * m_gravity) * Time.deltaTime; // Gravity calculation
        m_charController.Move(m_velocity * Time.deltaTime); // Vertical movement
       // Debug.Log(m_velocity.y);
    }

    void RunCheck()
    {
        if (Input.GetKeyDown(m_sprint))
        {
            m_finalSpeed = m_movementSpeed * m_runSpeed;
        }
        else if (Input.GetKeyUp(m_sprint))
        {
            m_finalSpeed = m_movementSpeed;
        }

    }

    void JumpCheck()
    {
    
        if (Input.GetKeyDown(m_jump))
        {
            if (m_isGrounded == true)
            {
                m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
            }
        }

    }

    bool HitGroundCheck()
    {
        bool isGrounded = Physics.CheckSphere(m_groundCheckPoint.position, m_groundDistance, m_groundMask);

        //Gravity
        if (isGrounded && m_velocity.y < -1)
        {
            m_velocity.y = -4f;
        }

        return isGrounded;
    }


}


