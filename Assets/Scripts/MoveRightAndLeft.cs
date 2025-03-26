using System.Collections;
using UnityEngine;

public class MoveRightAndLeft : MonoBehaviour
{
    private Rigidbody rb;
    private float rollingForce = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * rollingForce * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Swing()
    {

        yield return null;
    }
}
