using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 0f; // speed
    Rigidbody m_rigidBody;
    Vector3 m_Movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement = new Vector3(horizontal, 0, vertical).normalized;

        transform.position += m_Movement * moveSpeed * Time.deltaTime;

    }
}
