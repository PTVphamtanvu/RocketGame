using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rb;

    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotationThurst = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

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
                audioSource.PlayOneShot(mainEngine);

            }
            if (!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
        }
        else
        {
            mainEngineParticles.Stop();
            audioSource.Stop();
        }
    }

    void RotationProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotationInput(rotationThurst);
            if (!rightEngineParticles.isPlaying)
            {
                rightEngineParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationInput(-rotationThurst);
            if (!leftEngineParticles.isPlaying)
            {
                leftEngineParticles.Play();
            }
        }
        else
        {
            rightEngineParticles.Stop();
            leftEngineParticles.Stop();
        }
    }

    private void RotationInput(float rotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
