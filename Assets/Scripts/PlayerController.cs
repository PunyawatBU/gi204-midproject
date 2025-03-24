using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotateForce = 5;
    //[SerializeField] private float moveForce = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(moveForce * Vector3.forward);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(moveForce * Vector3.back);
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(moveForce * Vector3.left);
            transform.Rotate(Vector3.down * Time.deltaTime * rotateForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(moveForce * Vector3.right);
            transform.Rotate(Vector3.up * Time.deltaTime * rotateForce);
            
        }

        if (Input.GetKey(KeyCode.Space)&& isOnGround)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            isGameOver = true;
        }

    }
}
