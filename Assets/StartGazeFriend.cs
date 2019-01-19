using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGazeFriend : MonoBehaviour {

	// Use this for initialization
	void Start () {
        approach_talk.StartGaze += addTracking;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void addTracking()
    {
        this.gameObject.tag = "Clue";
    }
}
