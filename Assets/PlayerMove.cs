using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 0f; // speed
    public float verticalVelocity = 0.0f;
    public float gravity = 0.0f;
    //Rigidbody m_rigidBody;
    CharacterController m_characterController;
    Vector3 m_Movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //m_rigidBody = GetComponent<Rigidbody>();
        m_characterController = GetComponent<CharacterController>();
        gravity = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");

        // m_Movement = new Vector3(horizontal, 0, vertical).normalized;

        // transform.position += m_Movement * moveSpeed * Time.deltaTime;

    }

    void FixedUpdate()
    {
        m_Movement = Vector3.zero;

        if(m_characterController.isGrounded)
        {
            verticalVelocity = -0.2f;
        }
        else   
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        m_Movement.y = verticalVelocity;
        m_Movement.z = moveSpeed * Time.deltaTime;
        m_characterController.Move(m_Movement);
    }
}
