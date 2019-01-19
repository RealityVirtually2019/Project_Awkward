using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionPulser : MonoBehaviour {
    public bool collisionFlag = false;
    public float duration = 2.5F;
    Material myMat;
    // Use this for initialization
    void Start() {
        myMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update() {
        if (collisionFlag)
        {
            float phi = Time.time / duration * 2 * Mathf.PI;
            float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
            float R = amplitude;
            float G = amplitude;
            float B = amplitude/2;
            myMat.SetColor("_EmissionColor", new Color(R, G, B));
        }
        else {
            myMat.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
        }
    }

    public void setFlag(bool flag) {
        if (flag)
        {
            Debug.Log("gazed at, glow now");
        } else
        {
            Debug.Log("stopped gazing at");
        }
        collisionFlag = flag;
    }
}
