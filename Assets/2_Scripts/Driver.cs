using UnityEngine;

public class Driver : MonoBehaviour
{
    [Header("회전")]
    [SerializeField] float turnSpeed = 1f;
    [Header("속도")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float slowSpeedRatio = 0.5f;
    [SerializeField] float boostSpeedRatio = 1.5f;
    float slowSpeed;
    float boostSpeed;

    void Start()
    {
        slowSpeed = moveSpeed * slowSpeedRatio;
        boostSpeed = moveSpeed * boostSpeedRatio;
    }

    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boooost!!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}
