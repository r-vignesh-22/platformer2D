using UnityEngine;

public class KillZone : MonoBehaviour, IDangerZone
{
    public void ApplyDanger(PlayerRespawn player)
    {
        player.Respawn();
    }
}