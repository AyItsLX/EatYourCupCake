using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int AmountOfScore = 0;
    public Text ScoreUI;
    public GameObject Canvas;

    public static bool isStarted = false;
    public static bool isDead = false;

    public GameObject SpeedUpNotice;
    public GameObject JumpUpNotice;

    public float speedLimit = 20;
    public float waterLimit = 0.75f;
    public float jumpLimit = 6;

    public PlayerMovement playerMovement;
    public LoseTrigger loseTrigger;
    public bool[] speedUp;

    public AudioSource BGM;

	void Start ()
    {
        Canvas.SetActive(true);
        BGM = GetComponent<AudioSource>();
    }

    void Update()
    {
        ScoreUI.text = "Cupcake Eaten : " + AmountOfScore;

        if (isDead)
        {
            BGM.Stop();
        }

        if (speedUp[0])
        {
            if (playerMovement.movementSpeed < speedLimit)
            {
                playerMovement.movementSpeed += Time.deltaTime;
            }
            if (loseTrigger.waterSpeed < waterLimit)
            {
                loseTrigger.waterSpeed += Time.deltaTime * 0.25f;
            }
            if (playerMovement.jumpForce < jumpLimit)
            {
                playerMovement.jumpForce = jumpLimit;
            }
            else if (playerMovement.movementSpeed > speedLimit && loseTrigger.waterSpeed < waterLimit)
            {
                speedUp[0] = false;
            }
        }
    }
}
