using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHappy : MonoBehaviour {
    private AudioSource audioSource;
    private Animator anim;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        anim.Play("Looking Down");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void beHappy()
    {
        audioSource.Play();
        anim.Play("Talking");
    }
}
