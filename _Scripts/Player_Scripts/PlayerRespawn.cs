using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerRespawn : MonoBehaviour,IRespawnable
{
    PlayerController controller;
    

    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private Vector3 localScaleOnRespawn;    
    [SerializeField] private float respawnDelay = 2f;
    bool isDead;
    void Awake()
    {
        controller = GetComponent<PlayerController>();
        respawnPosition = transform.position;
        localScaleOnRespawn = transform.localScale;
        isDead = false;
        
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<IDangerZone>(out var danger) && !isDead)
        {
            isDead = true;
            danger.ApplyDanger(this);
        }

    }
    public void Respawn()
    {
        if (isDead)
        {
            StartCoroutine(DeadAndSpawning());
        }
    }
    IEnumerator DeadAndSpawning()
    {
        controller.SwitchState(PlayerState.Dead);
        isDead = true;
        PlayerParticleEffect.Instance.PlayDead();
        controller.body.linearVelocity = Vector2.zero;
        transform.localScale = Vector2.zero;

        ShadowCaster2D shadow = controller.GetComponent<ShadowCaster2D>();
        if (shadow != null) shadow.enabled = false;    

        BoxCollider2D collider = controller.GetComponent<BoxCollider2D>();
        collider.enabled = false;

        

        yield return new WaitForSeconds(respawnDelay);
        PlayerParticleEffect.Instance.StopDead();
        controller.body.linearVelocity = Vector2.zero;
        transform.position = respawnPosition;
        collider.enabled = true;
        
        transform.localScale = localScaleOnRespawn;

        shadow.enabled = true;
        isDead = false;
        controller.SwitchState(PlayerState.Normal);
    }
    public bool PlayerIsDead=>isDead;
}