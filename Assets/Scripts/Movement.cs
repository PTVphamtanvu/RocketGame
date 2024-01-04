using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotationThurst = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputProcess();
        RotationProcess();
    }

    void InputProcess()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }

    void RotationProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotationInput(rotationThurst);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationInput(-rotationThurst);
        }
    }

    private void RotationInput(float rotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
