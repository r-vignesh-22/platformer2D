using System.Collections;
using UnityEngine;

public class FallingObjectRespawner : MonoBehaviour
{
    private PlayerController player;
    private Vector3 originalPosition;

    private bool isRespawning = false;

    void Awake()
    {
        player = FindFirstObjectByType<PlayerController>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (player.IsDead && !isRespawning)
        {
            StartCoroutine(RespawnObject());
        }
    }

    IEnumerator RespawnObject()
    {
        isRespawning = true;

        float delayTime = 2.0f;
        yield return new WaitForSeconds(delayTime);

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (rigid == null)
        {
            Debug.LogWarning("Block does not have Rigidbody2D component.");
            isRespawning = false;
            yield break;
        }

        rigid.bodyType = RigidbodyType2D.Kinematic;
        rigid.linearVelocity = Vector2.zero;

        transform.position = originalPosition;

        isRespawning = false;
    }
}
