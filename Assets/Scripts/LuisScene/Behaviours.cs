using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviours : MonoBehaviour {
    public static Behaviours instance;

    // the following variables are references to possible targets
    internal GameObject gazedTarget;
    //internal GameObject continuouslygazedTarget;

    void Awake()
    {
        // allows this class instance to behave like a singleton
        instance = this;
    }

    public void SayHello(string utterance) {
        Debug.Log("Stage One Success!!! : " + utterance);
    }

    /// <summary>
    /// Determines which obejct reference is the target GameObject by providing its name
    /// </summary>
    private GameObject FindTarget(string name)
    {
        GameObject targetAsGO = null;

        switch (name)
        {
            //case "sphere":
            //    targetAsGO = sphere;
            //    break;

            //case "cylinder":
            //    targetAsGO = cylinder;
            //    break;

            //case "cube":
            //    targetAsGO = cube;
            //    break;

            case "this": // as an example of target words that the user may use when looking at an object
            case "it":  // as this is the default, these are not actually needed in this example
            case "that":
            default: // if the target name is none of those above, check if the user is looking at something
                if (gazedTarget != null)
                {
                    targetAsGO = gazedTarget;
                }
                break;
        }
        return targetAsGO;
    }


    ///Feature : glow what the player is interested in (mumbling like "oh that T-shirt") or gaze for 2-3 seconds
    ///refer : VREyeRaycaster
    public void GlowTarget(string targetName)
    {
        GameObject foundTarget = FindTarget(targetName);
        //check whether the player gaze the same item for around 2 secs.


        foundTarget.transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
    }
}
