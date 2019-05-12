using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("PlayerStats")]
    public float movementSpeed = 2f;
    public float jumpForce = 5f;
    public float isGroundedOffset = 0.5f;

    public bool isGrounded = false;
    public Rigidbody playerRB;

    public AudioSource jumpAudio;
    public AudioClip[] jumpSounds;

	void Start ()
    {
        jumpAudio = GetComponent<AudioSource>();
        jumpAudio.clip = jumpSounds[Random.Range(0, 3)];
    }
	
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * movementSpeed);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpAudio.clip = jumpSounds[Random.Range(0, 3)];
            jumpAudio.Play();
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
