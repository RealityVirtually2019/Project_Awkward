using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouchChipConvo : MonoBehaviour {
    private AudioSource audioSource;
    public ShirtClue shirt;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Invoke("StartClue", audioSource.clip.length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartClue()
    {
        shirt.StartTrack();
    }
}
