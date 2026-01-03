using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private float delayTime = 1.0f;
    Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.bodyType =RigidbodyType2D.Kinematic;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            StartCoroutine(DelayFall());
        }
    }
    IEnumerator DelayFall()
    {
        yield return new WaitForSeconds(delayTime);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
}
