using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 boxSize = new Vector2(0.8f, 0.2f);
    [SerializeField] private float distance = 0.5f;
    public bool IsGrounded => isGrounding;

    bool isGrounding;

    void Update()
    {
        isGrounding = Physics2D.BoxCast(
            transform.position,
            boxSize,
            0f,
            Vector2.down,
            distance,
            groundLayer
        );
    }
    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = isGrounding ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * distance, boxSize);
    }
}
