using UnityEngine;
using UnityEngine.SceneManagement;

public class LavelChanger : MonoBehaviour {
    public Animator animator;

    private int levelToload;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            FadeToLevel(1);
        }
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
