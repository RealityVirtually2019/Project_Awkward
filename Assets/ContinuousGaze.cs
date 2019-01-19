using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousGaze : MonoBehaviour {

    public bool enter = false;
    public bool stay = true;
    public bool exit = false;
    private float stayCount = 0.0f;

    public delegate void DetectGaze();
    public static event DetectGaze OnAcquaintanceGaze;

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            //Debug.Log("entered");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (stay && other.tag == "Clue")
        {
            if (stayCount > 2.0f)
            {
                // list cases here, based on other.name (MAYBE we don't even need cases here)
                switch (other.name)
                {
                    case "Talking friend":
                        stayCount = 0.0f;
                        // make the body glow
                        other.SendMessage("setFlag", true);
                        // fire an event to display the dialogue
                        if (OnAcquaintanceGaze != null)
                        {
                            OnAcquaintanceGaze();
                        }
                        break;
                    case "2":
                        Debug.Log("hi");
                        break;
                }
                
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit && other.tag == "Clue")
        {
            other.SendMessage("setFlag", false);
        }
    }
}
