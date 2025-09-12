using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;

    private void Awake()
    {
        if (FindObjectsOfType<InputManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        playerControls = new PlayerControls();
        playerControls.Gameplay.Enable();

        playerControls.Gameplay.Jump.performed += OnJumpPerformed;
    }

    private void OnDestroy()
    {
        // Evita erro de referência após trocar de cena
        if (playerControls != null)
        {
            playerControls.Gameplay.Jump.performed -= OnJumpPerformed;
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    public event Action OnJump;

    public float Movement => playerControls.Gameplay.Movement.ReadValue<float>();
}
