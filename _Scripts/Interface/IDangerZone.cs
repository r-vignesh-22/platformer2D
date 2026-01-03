using UnityEngine;

public interface IDangerZone 
{
    void ApplyDanger(PlayerRespawn player) => player.Respawn();
}