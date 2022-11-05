using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform GroundCheck;
    [SerializeField]
    private LayerMask GroundLayer;
    [SerializeField]
    private float movementSmoothing = .05f;
    [SerializeField]
    private float jumpForce = 400f;
    private Rigidbody2D rig;

    const float groundedRadius = .2f;

    private Vector3 velocity = Vector3.zero;

    float horizontalMove = 0f;
    bool jump = false;
    bool grounded = false;


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
                grounded = true;
        }
    }

    public void Move(float move, bool jump)
    {
        if (grounded)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, rig.velocity.y);
            rig.velocity = Vector3.SmoothDamp(rig.velocity, targetVelocity, ref velocity, movementSmoothing);

            //TODO: player sprite flip
        }

        if(grounded && jump)
        {
            Debug.Log("Du hast Jump gedrückt");
            grounded = false;
            rig.AddForce(new Vector2(2f, jumpForce));
        }
    }
}
