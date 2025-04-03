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
        Debug.Log("�ƾ� ! " + collision.gameObject.name, gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && !hasChicken)
        {
            Destroy(collision.gameObject, ChickenDelay);
            Debug.Log("ġŲ �Ⱦ���");
            spriteRenderer.color = hasChickenColor;
            hasChicken = true;
        }
        

        if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("ġŲ ��޵�");
            spriteRenderer.color = noChickenColor;
            hasChicken = false;
        }

    }

}
