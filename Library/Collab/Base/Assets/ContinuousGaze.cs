using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousGaze : MonoBehaviour {

    public bool enter = false;
    public bool stay = true;
    public bool exit = false;
    private float stayCount = 0.0f;
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
                Debug.Log("staying : " + other.name);
                stayCount = stayCount - 2.0f;
                other.SendMessage("setFlag",true);
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
            //Debug.Log("exit");
            other.SendMessage("setFlag", false);
        }
    }
}
