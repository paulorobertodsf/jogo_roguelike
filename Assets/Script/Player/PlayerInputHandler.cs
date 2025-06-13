using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerCombat))]
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerCombat combat;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
    }

    private void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        movement.SetDirection(direction);
    }

    private void OnFire()
    {
        combat.Fire();
    }
}
