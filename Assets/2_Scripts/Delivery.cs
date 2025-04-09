using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasChicken = false;
    [SerializeField] float ChickenDelay = 0.5f;

    [Header("Sprites")]
    [SerializeField] Sprite noChickenSprite;
    [SerializeField] Sprite hasChickenSprite;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = noChickenSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("아야 ! " + collision.gameObject.name, gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && !hasChicken)
        {
            Destroy(collision.gameObject, ChickenDelay);
            Debug.Log("치킨 픽업됨");
            spriteRenderer.sprite = hasChickenSprite;
            hasChicken = true;
        }


        if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("치킨 배달됨");
            Destroy(collision.gameObject, ChickenDelay);
            spriteRenderer.sprite = noChickenSprite;
            hasChicken = false;

            ScoreManager.Instance.AddScore(200);
            GameController.Instance.CustomerServed();
        }

    }

}
