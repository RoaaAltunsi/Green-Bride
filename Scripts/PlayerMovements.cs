using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking;
	public Transform playerTrans;

    public float jumpForce = 10.0f;  // Adjustable jump force
    private bool isGrounded = true; // Tracks whether the player is on the ground

    private bool isRunning = false; // Tracks the running state
	
	
	void FixedUpdate(){
		if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * (isRunning ? (w_speed + rn_speed) : w_speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
    
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.W)){
			playerAnim.SetTrigger("isWalk");
			playerAnim.ResetTrigger("isIdle");
			walking = true;
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.W)){
			playerAnim.ResetTrigger("isWalk");
			playerAnim.SetTrigger("isIdle");
			walking = false;
			//steps1.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.S)){
			playerAnim.SetTrigger("isWalkback");
			playerAnim.ResetTrigger("isIdle");
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.S)){
			playerAnim.ResetTrigger("isWalkback");
			playerAnim.SetTrigger("isIdle");
			//steps1.SetActive(false);
		}
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
		
        // Running logic
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Q))
        {
            isRunning = true;
            playerAnim.SetTrigger("isRun");
            playerAnim.ResetTrigger("isWalk");
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isRunning = false;
            playerAnim.ResetTrigger("isRun");
            // Set the walk trigger only if W is still being held
            if (Input.GetKey(KeyCode.W))
            {
                playerAnim.SetTrigger("isWalk");
            }
            else
            {
                playerAnim.SetTrigger("isIdle");
            }
        }

        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("isJump"); // Trigger the jump animation
        }
	}


    void OnCollisionEnter(Collision collision)
    {
        // Assuming the ground object has the tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnim.ResetTrigger("isJump");
        }
    }
}
