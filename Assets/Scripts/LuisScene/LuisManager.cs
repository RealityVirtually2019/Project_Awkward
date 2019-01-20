using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LuisManager : MonoBehaviour {
    [Serializable] //this class represents the LUIS response
    public class AnalysedQuery
    {
        public TopScoringIntentData topScoringIntent;
        public EntityData[] entities;
        public string query;
    }

    // This class contains the Intent LUIS determines 
    // to be the most likely
    [Serializable]
    public class TopScoringIntentData
    {
        public string intent;
        public float score;
    }

    // This class contains data for an Entity
    [Serializable]
    public class EntityData
    {
        public string entity;
        public string type;
        public int startIndex;
        public int endIndex;
        public float score;
    }

    public static LuisManager instance;

    //Substitute the value of luis Endpoint with your own End Point
    string luisEndpoint = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/f665418e-c8b4-44b0-9b9b-752374581ca2?verbose=true&timezoneOffset=-360&subscription-key=1b294e5d2a27472d87a096c29039e63c&q=";

    private void Awake()
    {
        // allows this class instance to behave like a singleton
        instance = this;
    }
    /// <summary>
    /// Call LUIS to submit a dictation result.
    /// The done Action is called at the completion of the method.
    /// </summary>
    public IEnumerator SubmitRequestToLuis(string dictationResult, Action done)
    {
        string queryString = string.Concat(Uri.EscapeDataString(dictationResult));

        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(luisEndpoint + queryString))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log(unityWebRequest.error);
            }
            else
            {
                try
                {
                    AnalysedQuery analysedQuery = JsonUtility.FromJson<AnalysedQuery>(unityWebRequest.downloadHandler.text);

                    //analyse the elements of the response 
                    AnalyseResponseElements(analysedQuery);
                }
                catch (Exception exception)
                {
                    Debug.Log("Luis Request Exception Message: " + exception.Message);
                }
            }

            done();
            yield return null;
        }
    }


    private void AnalyseResponseElements(AnalysedQuery aQuery)
    {
        string topIntent = aQuery.topScoringIntent.intent;

        // Create a dictionary of entities associated with their type
        Dictionary<string, string> entityDic = new Dictionary<string, string>();

        foreach (EntityData ed in aQuery.entities)
        {
            entityDic.Add(ed.type, ed.entity);
        }

        
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0: //hello
                string hello = null;
                foreach (var pair in entityDic)
                {
                    if (pair.Key == "hello")
                    {
                        hello = pair.Value;
                    }
                }
                LavelChanger.instance.Success(hello);
                break;
            case 1: //t-shirt
                string tshirt = null;
                string compl = null;
                foreach (var pair in entityDic)
                {
                    if (pair.Key == "T-shirt")
                    {
                        tshirt = pair.Value;
                    }
                    if (pair.Key == "compliments")
                    {
                        compl = pair.Value;
                    }
                }
                LavelChanger.instance.Success( tshirt + compl );
                break;
            case 2: //introFriend
                //Debug.Log("INTROFRIEND SCENE");
                string intro = null;
                string friend = null;
                foreach (var pair in entityDic)
                {
                    if (pair.Key == "intro")
                    {
                        intro = pair.Value;
                    }
                    if (pair.Key == "friend")
                    {
                        friend = pair.Value;
                    }
                }
                //Behaviours.instance.Success(intro + friend);
                LavelChanger.instance.Success(intro + friend);
                break;
        }
    }
}
