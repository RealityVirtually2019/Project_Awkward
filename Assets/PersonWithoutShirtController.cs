using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonWithoutShirtController : MonoBehaviour {
    public delegate void FinishScript();
    public static event FinishScript EndScriptTwo;

    // Use this for initialization
    void Start () {
        PersonWithShirtController.EndScriptOne += SayScriptTwo;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SayScriptTwo ()
    {
        Debug.Log("Hello two");
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        if (EndScriptTwo != null)
        {
            EndScriptTwo();
        }
    }
}
