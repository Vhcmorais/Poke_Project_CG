using UnityEngine;

public class IsGroundedChecker : MonoBehaviour
{
    [SerializeField] private Transform checkerPosition;
    [SerializeField] private Vector2 checkerSize = new Vector2(0.5f, 0.1f);
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        if (checkerPosition == null)
        {
            checkerPosition = transform.Find("GroundCheck");
            if (checkerPosition == null)
                Debug.LogWarning("IsGroundedChecker: CheckerPosition não atribuído e não encontrou 'GroundCheck' como filho.");
        }
    }

    public bool IsGrounded()
    {
        if (checkerPosition == null) return false;
        return Physics2D.OverlapBox(checkerPosition.position, checkerSize, 0f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (checkerPosition == null) return;
        Gizmos.color = IsGrounded() ? Color.red : Color.green;
        Gizmos.DrawWireCube(checkerPosition.position, checkerSize);
    }
}
