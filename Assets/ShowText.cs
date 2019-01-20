using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour {
    CanvasGroup canvasGroup;
	// Use this for initialization
	void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void showText()
    {
        innerShowText();
        //MicrophoneManager.instance.StartCapturingAudio();
    }

    void innerShowText()
    {
        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += 0.1f;
            Invoke("innerShowText", 0.1f);
        }
    }
}
