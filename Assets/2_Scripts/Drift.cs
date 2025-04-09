using UnityEditor.Rendering.LookDev;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Drift : MonoBehaviour
{
    [SerializeField] float acceleration = 20f;
    [SerializeField] float steering = 3f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float driftFactor = 0.95f; //ÀÌ °ªÀÌ ³·À»¼ö·Ï ´õ ¹Ì²ô·¯Áü

    [SerializeField] float slowAccelerationRatio = 0.5f;
    [SerializeField] float boostAccelerationRatio = 1.5f;

    [SerializeField] ParticleSystem smokeleft;
    [SerializeField] ParticleSystem smokeright;
    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;

    [SerializeField] TMP_Text speedText;

    Rigidbody2D rb;
    AudioSource audioSource;

    float defaultAcceleration;
    float slowAcceleration;
    float boostAcceleration;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = rb.GetComponent<AudioSource>();

        defaultAcceleration = acceleration;
        slowAcceleration = acceleration * slowAccelerationRatio;
        boostAcceleration = acceleration * boostAccelerationRatio;
    }

    void FixedUpdate()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (speed < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * acceleration);
        }

        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);

        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + sideVelocity * driftFactor;

    }

    private void Update()
    {
        float speed = rb.linearVelocity.magnitude;
        speedText.text = $"Speed: {speed:F1}";

        float sidewayVelocity = Vector2.Dot(rb.linearVelocity, transform.right);
        bool isDrifting = rb.linearVelocity.magnitude > 2f && Mathf.Abs(sidewayVelocity) > 1f;
        if (isDrifting)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeleft.isPlaying) smokeleft.Play();
            if (!smokeright.isPlaying) smokeright.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            if (smokeleft.isPlaying) smokeleft.Stop();
            if (smokeright.isPlaying) smokeright.Stop();
        }
        if (isDrifting && !audioSource.isPlaying) audioSource.Play();
        else if (!isDrifting && audioSource.isPlaying) audioSource.Stop();

        leftTrail.emitting = isDrifting;
        rightTrail.emitting = isDrifting;

    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Boost"))
        {
            acceleration = boostAcceleration;
            Debug.Log("Boooost!!!");

            Invoke(nameof(ResetAcceleration), 5f);
        }
    }

    void ResetAcceleration()
    {
        acceleration = defaultAcceleration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        acceleration = slowAcceleration;
        CameraShake.Instance.Shake(0.2f, 0.2f);
        Invoke(nameof(ResetAcceleration), 3f);
    }
}
