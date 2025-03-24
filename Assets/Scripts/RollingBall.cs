using UnityEngine;

public class RollingBall : MonoBehaviour
{
    private Rigidbody rb;
    private float rollingForce = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back*rollingForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
