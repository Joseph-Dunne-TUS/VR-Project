using UnityEngine;

public class TennisBallBounce : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bounceSound;

    [Header("Volume Settings")]
    public float minVolume = 0.1f;
    public float maxVolume = 1.0f;
    public float maxSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Get the ball's speed at the moment of collision
        float speed = rb.linearVelocity.magnitude;

        // Convert speed into a volume between minVolume and maxVolume
        float volume = Mathf.Clamp(speed / maxSpeed, minVolume, maxVolume);

        // Play the bounce sound with the calculated volume
        audioSource.PlayOneShot(bounceSound, volume);
    }
}
