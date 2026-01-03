using UnityEngine;

public class Steps : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.body.bodyType = RigidbodyType2D.Kinematic;
            player.body.gravityScale = 0f;
        }
    }
    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.body.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
