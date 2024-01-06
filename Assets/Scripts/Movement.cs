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
            OnThrusting();
        }
        else
        {
            StopThrsuting();
        }
    }

    void RotationProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotate();
        }
    }

    private void OnThrusting()
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

    private void StopThrsuting()
    {
        mainEngineParticles.Stop();
        audioSource.Stop();
    }

    private void RotationInput(float rotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    private void RotateRight()
    {
        RotationInput(-rotationThurst);
        if (!leftEngineParticles.isPlaying)
        {
            leftEngineParticles.Play();
        }
    }

    private void RotateLeft()
    {
        RotationInput(rotationThurst);
        if (!rightEngineParticles.isPlaying)
        {
            rightEngineParticles.Play();
        }
    }

    private void StopRotate()
    {
        rightEngineParticles.Stop();
        leftEngineParticles.Stop();
    }


}
