using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform GroundCheck;
    [SerializeField]
    private LayerMask GroundLayer;
    [SerializeField]
    private float movementSmoothing = .05f;
    [SerializeField]
    private float jumpForce = 400f;
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rig;

    const float groundedRadius = .2f;

    private Vector3 velocity = Vector3.zero;

    bool grounded = false;
    bool facingLeft = true;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        if (rig is null)
            Debug.LogError("Kein Rigidbody du Idiot");
    }


    private void FixedUpdate()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, groundedRadius, GroundLayer);
        
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }

        }
        animator.SetBool("grounded", grounded);
    }

    public void Move(float move, bool jump)
    {
        
            Vector3 targetVelocity = new Vector2(move * 10f, rig.velocity.y);
            rig.velocity = Vector3.SmoothDamp(rig.velocity, targetVelocity, ref velocity, movementSmoothing);

            

            if(move > 0 && facingLeft)
            {
                Flip();
            }
            else if(move < 0 && !facingLeft)
            {
                Flip();
            }
        

        if(grounded && jump)
        {
            Debug.Log("Du hast Jump gedrückt");
            grounded = false;
            animator.SetBool("grounded", grounded);
            rig.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
