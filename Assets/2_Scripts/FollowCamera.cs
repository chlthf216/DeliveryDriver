using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject followtarget;

     void LateUpdate()
    {
        transform.position = followtarget.transform.position + new Vector3(0, 0, -10);
    }
}
