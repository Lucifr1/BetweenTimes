using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public PlayerController controller;
	[SerializeField]
	private Animator animator;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	void Update()
	{
		if (!KatapultMechanism.catapultflying)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			animator.SetFloat("speed", Mathf.Abs(horizontalMove));

			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
				//animator.SetBool("grounded", !jump);
			}
		}
		
	}

	void FixedUpdate()
	{
		// Move our character
		if (!KatapultMechanism.catapultflying)
		{
			controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		}
		jump = false;
		//animator.SetBool("grounded", !jump);
	}
}