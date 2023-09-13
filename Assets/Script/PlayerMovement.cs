using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float movementSpeed;

    Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (verticalInput != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(verticalInput));
        }

        if (horizontalInput < 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
