using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour {
    public int speed;
	// Use this for initialization
	void Start () {
        ApproachCamera.PleaseSpeak += Speak;
	}
	
	// Update is called once per frame
	void Update () {
        // get input data from keyboard or controller
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // update player position based on input
        Vector3 position = transform.position;
        position.x += moveHorizontal * speed * Time.deltaTime;
        position.z += moveVertical * speed * Time.deltaTime;
        transform.position = position;

    }

    void Speak ()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Invoke("next_scene", 10);
    }

    void next_scene ()
    {
        SceneManager.LoadScene("second_scene");
    }
}
