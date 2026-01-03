using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerInputHandler input;
    private PlayerController controller;
    private GroundChecker groundChecker;
    [SerializeField] private float force = 5f;
    [SerializeField] private float jumperTimer = 1.0f;
    private float jumperCounter;
    private bool jumpPressed;
    private bool isJumping;
    void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
        controller = GetComponent<PlayerController>();
        groundChecker = GetComponent<GroundChecker>();
    }
    void OnEnable()
    {
        input.OnJump += value => jumpPressed = value;
    }
    void OnDisable()
    {
        input.OnJump -= value => jumpPressed = value;
    }
    void FixedUpdate()
    {
        if (controller.IsDead)
        {
            jumperCounter = jumperTimer;
            return;
        }
        if (controller.state == PlayerState.Dash) return;
        if (groundChecker.IsGrounded)
        {
            jumperCounter = jumperTimer;
            
        }

        if (jumpPressed && groundChecker.IsGrounded)
        {
            isJumping = true;
            PlayerParticleEffect.Instance.PlayDust();
            
            controller.body.linearVelocity = new Vector2(
                controller.body.linearVelocity.x,
                force
            );

        }
        if (isJumping && jumpPressed)
        {
            if (jumperCounter > 0)
            {
                jumperCounter -= Time.deltaTime;

                controller.body.linearVelocity = new Vector2(
                    controller.body.linearVelocity.x,
                    force
                );
            }
            else
            {
                isJumping = false;
            }
        }
        else if (!groundChecker.IsGrounded)
        {
            isJumping = false;
        }

    }
    
    
}