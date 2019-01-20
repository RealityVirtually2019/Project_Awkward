using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_approach : MonoBehaviour
{
    public int speed = 10;
    public bool play = true;
    public int dis = 30;

    private float speedx;
    private float speedz;
    private Vector3 camera_pos;

    public delegate void startTracking();
    public static event startTracking startVoice1;

    public int time_till_shrugging = 5;
    private Animator anim;

    public FadeInSayHi sayHi;

    public bool LevelDone = false;

    // Use this for initialization
    void Start()
    {
        // set the speed
        //Vector3 my_pos = this.transform.position;
        //camera_pos = GameObject.Find("Main Camera").transform.position;

        //Vector2 XZ_vector = new Vector2(camera_pos[0] - my_pos[0], camera_pos[2] - my_pos[2]);
        //float distance = Mathf.Sqrt(XZ_vector[0] * XZ_vector[0] + XZ_vector[1] * XZ_vector[1]);

        //// speed in x and z direction
        //speedx = speed * XZ_vector[0] / distance;
        //speedz = speed * XZ_vector[1] / distance;

        // say hello
        anim = GetComponent<Animator>();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Invoke("StartRecord", 2);
        Invoke("LookingDown", time_till_shrugging);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Distance() >= dis)
        //{
        //    Move();
        //}
        //else if (play)
        //{
        //    play = false;
            
        //}
    }

    void Move()
    {
        Vector3 pos = this.transform.position;
        pos[0] += speedx * Time.deltaTime;
        pos[2] += speedz * Time.deltaTime;
        this.transform.position = pos;
    }

    float Distance()
    {
        Vector3 my_pos = this.transform.position;
        Vector2 XZ_vector = new Vector2(camera_pos[0] - my_pos[0], camera_pos[2] - my_pos[2]);
        float distance = Mathf.Sqrt(XZ_vector[0] * XZ_vector[0] + XZ_vector[1] * XZ_vector[1]);
        return distance;
    }
    
    void StartRecord ()
    {
        if (startVoice1 != null)
        {
            startVoice1();
        }
    }

    void LookingDown()
    {
        if (!LevelDone)
        {
            anim.Play("Looking Down");
            sayHi.FadeInPopHi();
        }
    }

    public void Wave()
    {
        anim.Play("Wave");
    }
}
