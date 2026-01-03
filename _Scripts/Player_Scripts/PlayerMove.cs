using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInputHandler input;
    private PlayerController controller;   
    private GroundChecker groundChecker;
    
    [SerializeField] private float moveSpeed = 10f;
    private float moveInput;
    
    void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
        controller = GetComponent<PlayerController>();
        groundChecker = GetComponent<GroundChecker>();
        
    }
    void OnEnable()
    {
        input.OnMoveX += value => moveInput = value;
    }
    void OnDisable()
    {
        input.OnMoveX -= value => moveInput = value;
    }
    void Update()
    {
        if (controller.IsDead) return;
        if(controller.state==PlayerState.Dash) return;
        FlipPlayer();

        if (moveInput != 0 && groundChecker.IsGrounded)
        {
            PlayerParticleEffect.Instance.PlayDust();
        }
    }
    void FixedUpdate()
    {

        if (controller.IsDead) return;
        if(controller.state==PlayerState.Dash) return;
        

        controller.body.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            controller.body.linearVelocity.y
        );

    }
    void FlipPlayer()
    {
        if (moveInput != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (moveInput > 0 ? 1 : -1);
            transform.localScale = scale;            
        }

    }
    
}