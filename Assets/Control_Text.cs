using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_Text : MonoBehaviour {
    public Text testText;

	// Use this for initialization
	void Start () {
        testText.text = "";
        Invoke("turn_on", 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void turn_on ()
    {
        testText.text = "Success!";
    }
}
