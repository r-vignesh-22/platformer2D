using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;

    [Range(0.01f, 1f)]
    [SerializeField] private float smoothSpeed = 0.15f;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Vector2 xLimits;
    [SerializeField] private Vector2 yLimits;

    [SerializeField] private Vector3 offset;

    void Awake()
    {
        player = FindFirstObjectByType<PlayerController>().transform;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;

        
        targetPosition.x = Mathf.Clamp(targetPosition.x, xLimits.x, xLimits.y);
        targetPosition.y = Mathf.Clamp(targetPosition.y, yLimits.x, yLimits.y);

        
        targetPosition.z = transform.position.z;

        
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothSpeed
        );
    }
}
