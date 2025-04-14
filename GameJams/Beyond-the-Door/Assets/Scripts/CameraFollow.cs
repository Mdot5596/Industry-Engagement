using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag the Player here
    public float smoothing = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
