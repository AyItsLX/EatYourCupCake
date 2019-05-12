using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupcake : MonoBehaviour {

    private AudioSource biteAudio;

    public AudioClip[] biteSounds;

	void Start ()
    {
        biteAudio = GetComponent<AudioSource>();
        biteAudio.clip = biteSounds[Random.Range(0, 3)];
    }

    void Update()
    {
        transform.Rotate(Vector3.up * 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            biteAudio.Play();
            ++GameManager.AmountOfScore;

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Destroy(gameObject, 2f);
        }
    }
}
