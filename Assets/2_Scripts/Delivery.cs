using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasChicken = false;
    [SerializeField] float ChickenDelay = 0.5f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            spriteRenderer.color = hasChickenColor;
            hasChicken = true;
        }
        

        if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("치킨 배달됨");
            spriteRenderer.color = noChickenColor;
            hasChicken = false;
        }

    }

}
