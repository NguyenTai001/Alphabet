using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneProcess : MonoBehaviour
{
    public Text Leveltxt;
    string sceneNow ="SceneIndex";

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Leveltxt.text = "Level " + (PlayerPrefs.GetInt(pref.SceneNow) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
