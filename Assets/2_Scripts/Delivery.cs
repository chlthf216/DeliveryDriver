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
        Debug.Log("�ƾ� ! " + collision.gameObject.name, gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && !hasChicken)
        {
            Destroy(collision.gameObject, ChickenDelay);
            Debug.Log("ġŲ �Ⱦ���");
            spriteRenderer.sprite = hasChickenSprite;
            hasChicken = true;
        }


        if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("ġŲ ��޵�");
            Destroy(collision.gameObject, ChickenDelay);
            spriteRenderer.sprite = noChickenSprite;
            hasChicken = false;

            ScoreManager.Instance.AddScore(200);
            GameController.Instance.CustomerServed();
        }

    }

}
