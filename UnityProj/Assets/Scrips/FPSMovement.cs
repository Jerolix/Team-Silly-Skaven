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

    public bool isSprinting = false;
    public bool isWalking = false;
    public bool isJumping = false;

    public AudioSource walkSound;
    public AudioSource sprintSound;



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
            if (isSprinting == false && isWalking == false)
            {
                isWalking = true;
            }
            else if (isSprinting == true && isWalking == true)
            {
                isWalking = false;
            }
        }
       // print(move);
        MovePlayer(move);
        RunCheck(move);
        JumpCheck(); //check we jumpy jump
        PlaySounds();
    }

    void MovePlayer(Vector3 move)
    {
        if (move == Vector3.zero && isWalking == true)
        {
            isWalking = false;
        }
        m_charController.Move(move * m_finalSpeed * Time.deltaTime); // Stuff from WASD
        m_velocity.y += (1.2f * m_gravity) * Time.deltaTime; // Gravity calculation
        m_charController.Move(m_velocity * Time.deltaTime); // Vertical movement
       // Debug.Log(m_velocity.y);
    }

    void RunCheck(Vector3 move)
    {
        if (Input.GetKeyDown(m_sprint))
        {
            if (move != Vector3.zero)
            {
                isSprinting = true;
                m_finalSpeed = m_movementSpeed * m_runSpeed;
            }
        }
        else if (Input.GetKeyUp(m_sprint))
        {

             isSprinting = false;
            m_finalSpeed = m_movementSpeed;
        }
        
        if (move == Vector3.zero)
        {
            isSprinting = false;
            m_finalSpeed = m_movementSpeed;
        }
    }

    void PlaySounds()
    {
        if (isSprinting == false)
        {
            if (sprintSound.isPlaying == true)
            {
                sprintSound.Pause();
                print("Not Sprinting");
            }
        }
        else if (isSprinting == true)
        {
            if (sprintSound.isPlaying == false)
            {
                sprintSound.Play();
                if (walkSound.isPlaying == true)
                {
                    walkSound.Pause();
                }
                print("Sprinting");
            }
        }

        if (isWalking == false)
        {
            if (walkSound.isPlaying == true)
            {
                walkSound.Pause();
                print("Not Walking");
            }
        }
        else if (isWalking == true && isSprinting == false)
        {
            if (walkSound.isPlaying == false)
            {
                walkSound.Play();
                print("Walking");
            }
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


