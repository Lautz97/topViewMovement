using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSystem : MonoBehaviour {

    int hearts;

	// Use this for initialization
	void Awake () {
        hearts = 3;
	}

    public void YouGotHit() {
        hearts--;
    }
}


/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
