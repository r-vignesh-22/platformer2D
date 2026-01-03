using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerInputHandler input;
    PlayerController controller;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashDuration = 0.3f;
    [SerializeField] private float dashCooldown = 3.0f;
    [SerializeField]private bool canDash = true;
    private bool dashPressed;
    void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
        controller = GetComponent<PlayerController>();
        canDash = true;
    }
    void OnEnable() => input.OnDash += value => dashPressed = value;
    void OnDisable() => input.OnDash -= value => dashPressed = value;
    void Update()
    {
        if (controller.IsDead)
        {
            return;
        }  
             
        if(dashPressed && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }
    
    IEnumerator DashCoroutine()
    {
        canDash = false;
        controller.SwitchState(PlayerState.Dash);

        float originalGravity = controller.body.gravityScale;
        controller.body.gravityScale = 0f;

        controller.body.linearVelocity = new Vector2(
            dashForce * controller.FacingDirection,
            0f
        );

        yield return new WaitForSeconds(dashDuration);
        controller.body.gravityScale = originalGravity;
        controller.SwitchState(PlayerState.Normal);

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}