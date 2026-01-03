using UnityEngine;

public class AirBuster : MonoBehaviour
{
    [SerializeField] private float airForce = 10f;
    void OnTriggerStay2D(Collider2D trigger)
    {
        if(trigger.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            player.body.linearVelocity = new Vector2(
                player.body.linearVelocity.x,
                airForce
            );
        }
    }
}
