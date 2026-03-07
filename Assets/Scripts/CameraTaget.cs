using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void LateUpdate()
    {
        transform.position = playerTransform.position;
    }
}