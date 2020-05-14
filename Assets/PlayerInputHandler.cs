using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public bool AttackPressed = false;
    public bool AttackPressing = false;
    public event Action<Vector2> OnMove;
    public Vector2 Move = new Vector2();
    private PlayerControls playerControls;
    void OnEnable()
    {
        playerControls = new PlayerControls();

        playerControls.Player.Attack.performed += context => OnAttackPerformed(context);
        playerControls.Player.Attack.canceled += context => OnAttackCanceled(context);
        playerControls.Player.Move.performed += context => OnMovePerformed(context);

        playerControls.Enable();
    }
    void OnDisable()
    {
        playerControls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        Move = playerControls.Player.Move.ReadValue<Vector2>();
        if (Move != Vector2.zero)
        {
            if (OnMove != null)
            {
                OnMove(Move);
            }
        }
    }
    void LateUpdate()
    {
        AttackPressed = false;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        if (OnMove != null)
        {
            Vector2 move = context.ReadValue<Vector2>();
            OnMove(move);
        }
    }
    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        AttackPressed = true;
        AttackPressing = true;
    }
    private void OnAttackCanceled(InputAction.CallbackContext context)
    {
        AttackPressed = false;
        AttackPressing = false;
    }
}
