using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JSONReader : MonoBehaviour
{
    public TextAsset[] textJson;
    int poinMax = 0;
    int sceneIndex;
    [System.Serializable]
    
    public class objectEnemy
    {
        public string name;
        public int poin;
        public float scale;
    }
    [System.Serializable]
    public class SceneList
    {
        public objectEnemy[] Level;
    }
    public SceneList mySceneList = new SceneList();
    void Start()
    {
        
    }
    private void Awake()
    {
        sceneIndex = PlayerPrefs.GetInt(pref.SceneNow);
        Debug.Log(sceneIndex);
        for (int i = 0; i < textJson.Length; i++)
        {
            string s = textJson[i].name.Replace("JSONTextLevel ", "");
            Debug.Log(int.Parse(s));
            if (int.Parse(s) == sceneIndex)
            {
                Debug.Log(textJson[i].name);
                mySceneList = JsonUtility.FromJson<SceneList>(textJson[i].text);
                for (int j = 0; j < ArrayScene().Length; j++)
                {
                    poinMax = (poinMax < ArrayScene()[j].poin) ? ArrayScene()[j].poin : poinMax;
                }
            }
        }
        Debug.Log(poinMax);
    }
    public objectEnemy[] ArrayScene()
    {
        return mySceneList.Level;
    }
    public int getPoinMax()
    {
        return poinMax;
    }
}
