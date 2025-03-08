using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 0f; // speed
    public float verticalVelocity = 0.0f;
    public float gravity = 0.0f;
    public float rotateValue = 0.0f;

    public float negativeValue = 0.0f;
    public float positiveValue = 0.0f;
    //Rigidbody m_rigidBody;
    CharacterController m_characterController;
    Vector3 m_Movement;

    public PlayerRotateSwipe m_playerRotateSwipe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //m_rigidBody = GetComponent<Rigidbody>();
        m_characterController = GetComponent<CharacterController>();
        m_playerRotateSwipe.OnSwipe += HandleSwipe;
        gravity = 0.001f;
    }
    private void HandleSwipe(string direction)
    {
        if (direction == "Up")
            Jump();
        else if (direction == "Down")
            Slide();
        else if (direction == "Left")
            MoveLeft();
        else if (direction == "Right")
            MoveRight();
    }
    private void Jump() { Debug.Log("점프!"); }
    private void Slide() { Debug.Log("슬라이드!"); }
    private void MoveLeft() { Debug.Log("왼쪽 이동!"); rotateValue -= 90.0f; transform.eulerAngles = new Vector3(0.0f, rotateValue, 0.0f); }
    private void MoveRight() { Debug.Log("오른쪽 이동!"); rotateValue += 90.0f; transform.eulerAngles = new Vector3(0.0f, rotateValue, 0.0f); }

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
        //m_Movement.x = moveSpeed * Time.deltaTime;
        m_characterController.SimpleMove(new Vector3(0.0f, 0.0f, 0.0f));
        m_characterController.Move(m_Movement);

        Debug.Log(rotateValue);
    }
}
