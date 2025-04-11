using UnityEngine;

public class OffRoadSound : MonoBehaviour
{
    public AudioClip skidSound;
    private AudioSource audioSource;
    private bool isOnRoad = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Road"))
        {
            isOnRoad = true;
            Debug.Log("On the road (enter)");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Road"))
        {
            isOnRoad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Road"))
        {
            isOnRoad = false;
            Debug.Log("Off the road (exit)");
            audioSource.PlayOneShot(skidSound);
        }
    }
}

