using UnityEngine;

public enum ExitDirection
{
    Up,
    Down,
    Left,
    Right,
    Custom
}

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform targetLocation;
    [SerializeField] private ExitDirection exitDirection = ExitDirection.Up;
    [SerializeField] private Vector2 customDirection = Vector2.up;

    [SerializeField] private float exitDistance = 0.5f;
    [SerializeField] private float exitSpeed = 5f;

    private static float teleportCooldownTime = 0.2f;
    private static float nextAvailableTeleportTime = 0f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Time.time < nextAvailableTeleportTime) 
            return; // Prevent back-and-forth loop

        if (collider.TryGetComponent<PlayerController>(out var player))
        {
            ActivatePortal(player);
        }
    }

    void ActivatePortal(PlayerController player)
    {
        Vector2 dir = GetExitDirection();

        // Set cooldown so player cannot re-enter instantly
        nextAvailableTeleportTime = Time.time + teleportCooldownTime;

        // Move player slightly outside the portal
        Vector2 exitPos = (Vector2)targetLocation.position + dir * exitDistance;
        player.transform.position = exitPos;

        // Push player away
        player.body.linearVelocity = dir * exitSpeed;
    }

    private Vector2 GetExitDirection()
    {
        switch (exitDirection)
        {
            case ExitDirection.Up: return Vector2.up;
            case ExitDirection.Down: return Vector2.down;
            case ExitDirection.Left: return Vector2.left;
            case ExitDirection.Right: return Vector2.right;
            case ExitDirection.Custom: return customDirection.normalized;
            default: return Vector2.up;
        }
    }
}
