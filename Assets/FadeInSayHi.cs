using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInSayHi : MonoBehaviour {
    private CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {
		canvasGroup = GetComponent<CanvasGroup>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeInPopHi ()
    {
        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += 0.1f;
            Invoke("FadeInPopHi", 0.1f);
        }
    }

    public void FadeOutHi()
    {
        if (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= 0.1f;
            Invoke("FadeOutHi", 0.1f);
        }
    }
}
