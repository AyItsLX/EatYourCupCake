using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public GameObject GameOverUI;
    public GameObject LoseTriggerObj;
    public Text Description;
    public AudioSource winAudio;

	void Start ()
    {
        winAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winAudio.Play();
            Description.text = "You've Cleared the Stage!";
            GameOverUI.SetActive(true);
            other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().enabled = false;
            LoseTriggerObj.GetComponent<LoseTrigger>().enabled = false;
        }
    }
}
