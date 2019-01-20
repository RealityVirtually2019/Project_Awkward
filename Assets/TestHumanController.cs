using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHumanController : MonoBehaviour {
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.Play("Pointing Forward");
        Invoke("PlayLookDown", 15);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayLookDown ()
    {
        Debug.Log("Playing Looking down");
        anim.Play("Lookdown");
    }
}
