using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private PlayerActions playerActions;
    private Rigidbody2D rig;
    private Vector2 moveInput;


    // Start is called before the first frame update
    void Start()
    {
        //playerActions.Player_Map.Jump.performed += JumpPerformed;
    }

    private void Awake()
    {
        playerActions = new PlayerActions();
        rig = GetComponent<Rigidbody2D>();
        if (rig is null)
            Debug.LogError("Kein Rigidbody du Idiot");

  
    }

    private void OnEnable()
    {
        playerActions.Player_Map.Enable();
    }

    private void OnDisable()
    {
        playerActions.Player_Map.Disable();
    }

    private void FixedUpdate()
    {
        moveInput = playerActions.Player_Map.Movement.ReadValue<Vector2>();
        moveInput.y = 0;
        rig.velocity = moveInput * speed;
        if (playerActions.Player_Map.Jump.triggered)
        {
            Jump();
        }
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        rig.AddForce(Vector2.up * 150f, ForceMode2D.Impulse);
        //rig.velocity.y = 
        Debug.Log("Werde ich jemals aufgerufen?");
    }

    private void Jump()
    {
        rig.AddForce(Vector2.up * 150f, ForceMode2D.Impulse);
    }
}
