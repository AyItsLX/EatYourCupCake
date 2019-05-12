using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    GameManager gameManager;

    AudioSource speedUpAudio;

	void Start ()
    {
        speedUpAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "SpeedUp1")
            {
                speedUpAudio.Play();
                gameManager.SpeedUpNotice.SetActive(true);
                gameManager.speedUp[0] = true;
                gameManager.speedLimit = 25;
                gameManager.waterLimit = 1.25f;
                gameManager.jumpLimit = 7;
            }
            else if (gameObject.name == "JumpUp1")
            {
                speedUpAudio.Play();
                gameManager.JumpUpNotice.SetActive(true);
                gameManager.speedUp[0] = true;
                gameManager.jumpLimit = 10;
                gameManager.waterLimit = 1.5f;
            }
            else if (gameObject.name == "SpeedUp2")
            {
                speedUpAudio.Play();
                gameManager.SpeedUpNotice.SetActive(true);
                gameManager.speedUp[0] = true;
                gameManager.speedLimit = 27.5f;
                gameManager.waterLimit = 1.6f;
                gameManager.jumpLimit = 10;
            }
            else if (gameObject.name == "JumpUp2")
            {
                speedUpAudio.Play();
                gameManager.SpeedUpNotice.SetActive(true);
                gameManager.speedUp[0] = true;
                gameManager.speedLimit = 27.5f;
                gameManager.waterLimit = 1.75f;
                gameManager.jumpLimit = 15;
            }
        }
    }
}
