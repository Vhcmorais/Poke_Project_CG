using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;

    private Rigidbody2D rb;
    private IsGroundedChecker isGroundedChecker;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        isGroundedChecker = GetComponentInChildren<IsGroundedChecker>();
        if (isGroundedChecker == null)
            Debug.LogWarning("IsGroundedChecker não encontrado no Player ou nos filhos!");
    }

    private void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.InputManager != null)
        {
            GameManager.Instance.InputManager.OnJump += HandleJump;
        }
    }

    private void Update()
    {
        float moveDirection = GameManager.Instance.InputManager != null ? GameManager.Instance.InputManager.Movement : 0f;

        // Movimento horizontal
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, 0, 0);

        // Virar o Player de acordo com a direção
        if (moveDirection < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (moveDirection > 0)
            transform.localScale = Vector3.one;
        }

    private void HandleJump()
    {
        if (isGroundedChecker == null) return;
        if (!isGroundedChecker.IsGrounded()) return;

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}