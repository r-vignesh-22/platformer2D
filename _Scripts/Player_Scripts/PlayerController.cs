using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body { get; private set; }
    public PlayerState state { get; private set; }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        SwitchState(PlayerState.Normal);
    }
    
    public void SwitchState(PlayerState newState)
    {
        state = newState;
        if(newState == PlayerState.Dead)
        {
            
            body.linearVelocity = Vector2.zero;            
        }
            
        
    }
    public bool IsDead => state == PlayerState.Dead;
    public int FacingDirection => (int)Mathf.Sign(transform.localScale.x);
    
}