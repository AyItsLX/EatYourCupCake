using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject Player;
    public Vector3 cameraOffset;
    public float offsetYPosition = 1f;

	void Start () {}
	
	void Update ()
    {
        transform.position = new Vector3(0, Player.transform.position.y + offsetYPosition, 0);

        transform.LookAt(Player.transform.position + cameraOffset);
	}
}
