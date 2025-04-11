using TMPro;
using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] float acceleration = 20f;
    [SerializeField] float steering = 3f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float driftFactor = 0.95f; //이 값이 낮을수록 더 미끄러짐

    [SerializeField] float slowAccelerationRatio = 0.5f;
    [SerializeField] float boostAccelerationRatio = 1.5f;

    [SerializeField] ParticleSystem smokeleft;
    [SerializeField] ParticleSystem smokeright;

    [SerializeField] float maxDriftIntensity = 5f; // 드리프트 세기 최대값
    [SerializeField] float maxEmissionRate = 50f;  // 최대 연기량

    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;

    [SerializeField] TMP_Text speedText;

    [SerializeField] ParticleSystem speedLines;
    [SerializeField] float speedLineThreshold = 5f;

    [SerializeField] float BoostDelay = 0.5f;

    Rigidbody2D rb;
    AudioSource audioSource;

    float defaultAcceleration;
    float slowAcceleration;
    float boostAcceleration;
    private ParticleSystem.EmissionModule leftEmission;
    private ParticleSystem.EmissionModule rightEmission;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = rb.GetComponent<AudioSource>();

        defaultAcceleration = acceleration;
        slowAcceleration = acceleration * slowAccelerationRatio;
        boostAcceleration = acceleration * boostAccelerationRatio;

        leftEmission = smokeleft.emission;
        rightEmission = smokeright.emission;
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

        if (speed >= speedLineThreshold)
        {
            if (!speedLines.isPlaying) speedLines.Play();
        }
        else
        {
            if (speedLines.isPlaying) speedLines.Stop();
        }

        float sidewayVelocity = Vector2.Dot(rb.linearVelocity, transform.right);
        bool isDrifting = rb.linearVelocity.magnitude > 2f && Mathf.Abs(sidewayVelocity) > 1f;

        float driftIntensity = Mathf.Clamp01(Mathf.Abs(sidewayVelocity) / maxDriftIntensity);
        float emissionRate = driftIntensity * maxEmissionRate;

        leftEmission.rateOverTime = emissionRate;
        rightEmission.rateOverTime = emissionRate;

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
            Destroy(collison.gameObject, BoostDelay);

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
