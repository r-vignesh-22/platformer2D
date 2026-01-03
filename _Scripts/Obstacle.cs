using UnityEngine;

public class Obstacle : MonoBehaviour, IDangerZone
{
    public void ApplyDanger(PlayerRespawn player)
    {
        player.Respawn();
    }
}
