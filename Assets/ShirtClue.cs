using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtClue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTrack()
    {
        this.gameObject.tag = "Clue";
    }
}
