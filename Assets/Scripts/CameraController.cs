using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float velocity = 1;
    [SerializeField] private Vector3 displacement;
    private void LateUpdate()
    {
        Vector3 position = target.position + displacement;
        Vector3 positionSmoothed = Vector3.Lerp(transform.position, position, velocity);
        transform.position = positionSmoothed;
    }
}
