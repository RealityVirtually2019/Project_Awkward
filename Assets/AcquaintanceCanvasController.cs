using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquaintanceCanvasController : MonoBehaviour {
    CanvasGroup canvasGroup;
    public float speed = 0.3f;
    private bool shown = false;
    public LavelChanger levelChanger;

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
        //MicrophoneManager.instance.StartCapturingAudio();
        if (!shown)
        {
            shown = true;
            Show();
        }

        Invoke("End", 8);
        //start dictation
        //MicrophoneManager.instance.StartCapturingAudio();
    }

    void End()
    {
        levelChanger.CompleteRound();
    }

    void Show ()
    {
        Debug.Log("actually showing");
        Debug.Log(canvasGroup.alpha);
        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += speed;
            Invoke("Show", 0.1f);
        }
    }
}
