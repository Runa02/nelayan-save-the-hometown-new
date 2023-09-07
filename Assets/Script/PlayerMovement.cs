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
        if(verticalInput != 0){
            animator.SetFloat("Speed", Mathf.Abs(verticalInput));
        }
        
        if(Input.GetKeyDown(KeyCode.D)){
            transform.eulerAngles = new Vector3 (0, -190, 0);
        }if(Input.GetKeyDown(KeyCode.A)){
            transform.eulerAngles = new Vector3 (0, 0, 0);
        }
    }
}
