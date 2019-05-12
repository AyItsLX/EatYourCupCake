using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

    public PlayerMovement playerMovement;
    public Animator playerAnimator;
    public Rigidbody thisRB;

    public bool isInAir = false;

    void Start() { }

    void Update()
    {
        #region CheckGround
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, playerMovement.isGroundedOffset))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * playerMovement.isGroundedOffset, Color.blue);
            if (hit.collider.CompareTag("Ground"))
            {
                playerMovement.isGrounded = true;
            }
            else
            {
                playerMovement.isGrounded = false;
            }

        }
        else
        {
            playerMovement.isGrounded = false;
        }
        #endregion

        #region CheckFall
        RaycastHit checkFall;

        if (thisRB.velocity.y < -1 && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out checkFall, 1))
        {
            if (isInAir && checkFall.collider.CompareTag("Ground"))
            {
                playerAnimator.SetBool("Run", true);
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * playerMovement.isGroundedOffset, Color.red);
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetTrigger("Anticipate");
        }

        if (thisRB.velocity.y > 2)
        {
            isInAir = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (thisRB.velocity.y < 0 && isInAir && collision.collider.CompareTag("Ground"))
        {
            playerAnimator.SetBool("Run", true);
            isInAir = false;
        }
    }
}
