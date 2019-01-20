using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Behaviours : MonoBehaviour
{
    public static Behaviours instance;

    // the following variables are references to possible targets
    internal GameObject gazedTarget;
    //internal GameObject continuouslygazedTarget;

    void Awake()
    {
        // allows this class instance to behave like a singleton
        instance = this;
    }

    public void SayHello(string utterance)
    {
        Debug.Log("Stage One Success!!! : " + utterance);
    }
    public void IntroFriend(string utterance)
    {
        Debug.Log("!!!Success from Befaviors!!! : " + utterance);
        //confetti.Play();
        //levelchangerInstance.Invoke("FadeToNextLevel", 5.0f);
        //StartCoroutine(success());
        //Invoke("callLevelChange",5.0f);
    }
    //IEnumerator success()
    //{
    //    confetti.Play();
    //    yield return new WaitForSeconds(5);
    //    levelchangerInstance.FadeToNextLevel();
    //}
    //private void callLevelChange()
    //{
    //    referLeverChanger.FadeToNextLevel();
    //}
    /// <summary>
    /// Determines which obejct reference is the target GameObject by providing its name
    /// </summary>



}
