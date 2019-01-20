using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonWithShirtController : MonoBehaviour {
    public delegate void FinishScript();
    public static event FinishScript EndScriptOne;

	// Use this for initialization
	void Start () {
        PersonWithoutShirtController.EndScriptTwo += StartTracking;

        // wait for 3 seconds and say first line
        Invoke("SayScriptOne", 6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SayScriptOne()
    {
        Debug.Log("Hello One");
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        float length = audioSource.clip.length;
        Invoke("FireEventEndScriptOne", length);
    }

    void FireEventEndScriptOne()
    {
        if (EndScriptOne != null)
        {
            EndScriptOne();
        }
    }

    void StartTracking()
    {
        GameObject.Find("Shirt").tag = "Clue";
    }
}
