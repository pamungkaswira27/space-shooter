using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] float moveSpeed;

    [Header("Screen Padding")]
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Animator animator;
    Shooter shooter;

    Vector2 moveInput;
    Vector2 minBound;
    Vector2 maxBound;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;

        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = moveInput * moveSpeed * Time.deltaTime;

        if (moveInput.x > 0)
        {
            animator.SetFloat("MoveDirection", moveInput.x);
        }
        else if (moveInput.x < 0)
        {
            animator.SetFloat("MoveDirection", moveInput.x);
        }
        else if (moveInput.x == 0)
        {
            animator.SetFloat("MoveDirection", moveInput.x);
        }

        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
