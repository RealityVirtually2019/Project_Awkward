using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LavelChanger.PopUpLogo += LogoFadeIn;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LogoFadeIn()
    {
        CanvasGroup canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha += 0.1f;
        Invoke("LogoFadeIn", 0.1f);
    }

}
