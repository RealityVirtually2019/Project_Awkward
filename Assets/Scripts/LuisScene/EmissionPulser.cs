using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionPulser : MonoBehaviour {
    public string collisionFlag = "idle";
    public float duration = 5.0F;
    Material myMat;
    // Use this for initialization
    void Start() {
        myMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update() {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        switch (collisionFlag)
        {
            case "idle":
            float R = amplitude/1;
            float G = amplitude/1;
            float B = amplitude/2;
            myMat.SetColor("_EmissionColor", new Color(R, G, B));
                break;
            case "activated":
            myMat.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
                break;
                
        }
    }

    public void setFlag(string flag) {
        // GLOW!!!????
        collisionFlag = flag;
    }
}
