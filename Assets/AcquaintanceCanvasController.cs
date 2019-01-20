using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquaintanceCanvasController : MonoBehaviour {
    CanvasGroup canvasGroup;
    public float speed = 0.3f;
    private bool shown = false;

	// Use this for initialization
	void Start () {
        ContinuousGaze.OnAcquaintanceGaze += ShowWrapper;
        canvasGroup = GetComponent<CanvasGroup>();

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void ShowWrapper()
    {
        if (!shown)
        {
            shown = true;
            Show();
        }
        //start dictation
        MicrophoneManager.instance.StartCapturingAudio();
    }

    void Show ()
    {
        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += speed;
            Invoke("Show", 0.1f);
        }
    }
}
