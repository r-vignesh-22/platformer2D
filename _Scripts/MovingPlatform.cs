using UnityEngine;
public enum PlatformMovementType { MoveTowards, Lerp, SmoothDamp }

public class MovingPlatform : MonoBehaviour
{
    public PlatformMovementType movementType = PlatformMovementType.MoveTowards;

    [SerializeField] private Transform[] points;
    [SerializeField] private float speed = 2f;
    private int currentPointIndex = 0;

    private Vector3 dampVelocity = Vector3.zero;
    public float dampTime = 0.3f;   

    void FixedUpdate()
    {
        if (points.Length == 0) return;

        Transform targetPoint = points[currentPointIndex];

        switch (movementType)
        {
            case PlatformMovementType.MoveTowards:
                MoveTowardsMovement(targetPoint);
                break;

            case PlatformMovementType.Lerp:
                LerpMovement(targetPoint);
                break;

            case PlatformMovementType.SmoothDamp:
                SmoothDampMovement(targetPoint);
                break;
        }

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }

    void MoveTowardsMovement(Transform target)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );
    }

    void LerpMovement(Transform target)
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );
    }

    void SmoothDampMovement(Transform target)
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position,
            ref dampVelocity,
            dampTime
        );
    }
}



