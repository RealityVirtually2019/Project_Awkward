using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachCamera : MonoBehaviour {
    public int speed;
    private float speedx;
    private float speedz;
    public bool play = true;

    // event
    public delegate void Speak();
    public static event Speak PleaseSpeak;

	// Use this for initialization
	void Start () {
        Debug.Log(this.transform.position);
        float x_pos = this.transform.position[0];
        float z_pos = this.transform.position[2];
        float overall = Mathf.Sqrt(x_pos * x_pos + z_pos * z_pos);
        speedx = x_pos / overall;
        speedz = z_pos / overall;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position[0] > 4)
        {
            Vector3 pos = this.transform.position;
            pos[0] -= speedx * speed * Time.deltaTime;
            pos[2] -= speedz * speed * Time.deltaTime;
            this.transform.position = pos;
        }
        else if (play)
        {
            play = false;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Invoke("next", 2);
        }
	}

    void next()
    {
        Debug.Log("next");
        if (PleaseSpeak != null)
        {
            PleaseSpeak();
        }
    }
}
