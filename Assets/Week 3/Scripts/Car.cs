using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float forwardInput;
    float steeringInput;
    public float forwardSpeed = 500f;
    public float steeringSpeed = 200f;
    Rigidbody2D rigidbody;
    public float maxSpeed = 450f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbody.AddTorque(steeringInput * -steeringSpeed * Time.deltaTime);
        Vector2 force = transform.up * forwardInput * forwardSpeed * Time.deltaTime;
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(force);
        }
    }
}
