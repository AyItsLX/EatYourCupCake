using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseTrigger : MonoBehaviour {

    public float waterSpeed = 5f;
    public GameObject GameOverUI;
    public Text Description;
    public bool isWaterMoving = true;
    public AudioSource loseAudio;

    void Start ()
    {
        loseAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isWaterMoving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * waterSpeed, transform.position.z);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Description.text = "YOU DEAD!\nTRY HARDER NEXT TIME!";
            GameManager.isDead = true;
            isWaterMoving = false;
            GameOverUI.SetActive(true);
            other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loseAudio.Play();
        }
    }
}
