using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rb;
    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotationThurst = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }
        else
        {
            audioSource.Stop();
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
