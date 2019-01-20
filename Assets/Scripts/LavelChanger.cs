using UnityEngine;
using UnityEngine.SceneManagement;

public class LavelChanger : MonoBehaviour {
    public static LavelChanger instance;
    public Animator animator;
    private int levelToload;

    public ParticleSystem confetti;
    public LogoPopup logo;
    // Update is called once per frame
    public FadeInSayHi sayHi;

    // event
    public delegate void PopUp();
    public static event PopUp PopUpLogo;

    private bool startedTracking1;

    public intro_approach man;
    public PlaneTalk plane;

    void Awake()
    {
        intro_approach.startVoice1 += startTrack1;
        // allows this class instance to behave like a singleton
        instance = this;
    }
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            FadeToNextLevel();
        }
	}

    void startTrack1()
    {
        startedTracking1 = true;
    }

    public void Success(string utterance) {
        //if (startedTracking1)
        {
            Debug.Log("complete round!!!!");
                man.LevelDone = true;
                plane.Talk();
                man.Wave();
                sayHi.FadeOutHi();
                logo.LogoFadeIn();
            confetti.Play();
            Invoke("FadeToNextLevel", 5);

            //    man.LevelDone = true;
            //plane.Talk();
            //man.Wave();
            //sayHi.FadeOutHi();
            //logo.LogoFadeIn();
            //if (PopUpLogo != null)
            //{
            //    PopUpLogo();
            //}

            //MicrophoneManager.instance.StopCapturingAudio();


        }
    }

    public void CompleteRound()
    {
        confetti.Play();
        Invoke("FadeToNextLevel", 5);
    }

    public void FadeToNextLevel() {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeToLevel(int levelIndex){
        levelToload = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToload);
    }
}   
