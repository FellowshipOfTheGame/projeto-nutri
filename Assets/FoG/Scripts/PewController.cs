using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class PewController : MonoBehaviour
{
    [SerializeField]
    public float playerVelocity;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string walkingAnimatorName = "IsWalking";

    private PlayerControl playerControl;
    private Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector3 scale;

    bool isFlipped = false;

    // Start is called before the first frame update
    void Awake()
    {
        playerControl = new PlayerControl();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void OnEnable()
    {
        playerControl.Player.Enable();
    }

    void OnDisable()
    {
        playerControl.Player.Disable();
    }

    void Move()
    {
        moveInput = playerControl.Player.Move.ReadValue<Vector2>();

        if (moveInput.magnitude > 0)
        {
            animator.SetBool(walkingAnimatorName, true);
            rb.velocity = moveInput * playerVelocity;

            if (moveInput.x > 0 && !isFlipped)
            {
                FlipPlayer();
            }
            else if (moveInput.x < 0 && isFlipped)
            {
                FlipPlayer();
            }
        }
        else
        {
            animator.SetBool(walkingAnimatorName, false);
            rb.velocity = Vector2.zero;
        }
    }

    void FlipPlayer()
    {
        isFlipped = !isFlipped;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
