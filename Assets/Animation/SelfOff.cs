using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfOff : MonoBehaviour {

	void Start () {
		
	}

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
